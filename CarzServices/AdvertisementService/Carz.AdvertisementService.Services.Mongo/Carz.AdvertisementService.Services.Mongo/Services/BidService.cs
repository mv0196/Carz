using AutoMapper;
using Carz.AdvertisementService.Domain.Commands.Bid;
using Carz.AdvertisementService.Domain.Entities;
using Carz.AdvertisementService.Domain.Queries.Bid;
using Carz.AdvertisementService.Domain.Services;
using Carz.AdvertisementService.Services.Mongo.Contexts;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Services.Mongo.Services
{
    public class BidService : IBidService
    {
        private readonly ILogger<BidService> _logger;
        private readonly AdvertisementDbContext _context;
        private readonly IMapper _mapper;

        public BidService(ILogger<BidService> logger, AdvertisementDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Bid>> GetAllBidsByUser(GetAllBidsByUserQuery query, CancellationToken cancellationToken = default)
        {
            var userFilter = Builders<Bid>.Filter.Eq("UserId", query.UserId);

            List<Bid> bids = await (await _context.Bids.FindAsync(userFilter, null, cancellationToken)).ToListAsync(cancellationToken);
            return bids;
        }

        public async Task<List<Bid>> GetWonBidsByUser(GetWonBidsByUserQuery query, CancellationToken cancellationToken = default)
        {
            var userFilter = Builders<Bid>.Filter.Eq("UserId", query.UserId);
            var wonFilter = Builders<Bid>.Filter.Eq("Won", true);

            List<Bid> bids = await (await _context.Bids.FindAsync(userFilter & wonFilter, null, cancellationToken)).ToListAsync(cancellationToken);
            return bids;
        }

        public async Task<Bid> PlaceBid(PlaceBidCommand command, CancellationToken cancellationToken = default)
        {
            var adFilter = Builders<Advertisement>.Filter.Eq("_id", command.AdvertisementId);
            var userBidFilter = Builders<Bid>.Filter.Eq("UserId", command.UserId);
            var adBidFilter = Builders<Bid>.Filter.Eq("AdvertisementId", command.AdvertisementId);


            Advertisement ad = await (await _context.Advertisements.FindAsync(adFilter, null, cancellationToken)).FirstOrDefaultAsync(cancellationToken);

            if (ad == null)
            {
                _logger.LogInformation("Unable to place bif for Advertisement : {AdvertisementId} by User : {UserId} as the advertisement is not found", command.AdvertisementId, command.UserId);
                return null;
            }

            // At this point, we are sure that the advertisement exists
            using (var session = await _context.Client.StartSessionAsync())
            {
                // Begin transaction
                session.StartTransaction();
                try
                {
                    // Did user already have an existing bid?
                    // If so update it
                    int existingAdBidIndex = ad.Bids.FindIndex(a => a.UserId == command.UserId);
                    if (existingAdBidIndex != -1)
                    {
                        _logger.LogInformation("Found existing bid while placing bid for Advertisement : {AdvertisementId} by User : {UserId}", command.AdvertisementId, command.UserId);
                        // Only update oif there is a change
                        if (ad.Bids[existingAdBidIndex].Price != command.Price)
                        {
                            ad.Bids[existingAdBidIndex].Price = command.Price;
                            var updateAd = Builders<Advertisement>.Update.Set(a => a.Bids, ad.Bids);
                            var res = await _context.Advertisements.UpdateOneAsync(adFilter, updateAd, null, cancellationToken);
                            if (res.IsAcknowledged != true)
                            {
                                // Update not acknowledged, so abort
                                _logger.LogInformation("Updating Bid in Advertisement : {AdvertismenetId} by User : {UserId} failed because update is not acknowledged", command.AdvertisementId, command.UserId);
                                await session.AbortTransactionAsync(cancellationToken);
                                return null;
                            }

                            // Update in Bids as well
                            var bidUserFilter = Builders<Bid>.Filter.Eq("UserId", command.UserId);
                            var bidAdFilter = Builders<Bid>.Filter.Eq("AdvertisementFilter", command.AdvertisementId);
                            var updateBid = Builders<Bid>.Update
                                .Set(b => b.Price, command.Price)
                                .Set(a => a.UpdatedBy, command.UserId)
                                .Set(a => a.UpdatedAt, DateTime.Now)
                                .Set(a => a.UpdatedPublished, false);
                            res = await _context.Bids.UpdateOneAsync(bidUserFilter & bidAdFilter, updateBid, null, cancellationToken);
                            if (res.IsAcknowledged != true)
                            {
                                // Update not acknowledged, so abort
                                _logger.LogInformation("Updating Bid in Bids collection for Advertisement : {AdvertismenetId} by User : {UserId} failed because update is not acknowledged", command.AdvertisementId, command.UserId);
                                await session.AbortTransactionAsync(cancellationToken);
                                return null;
                            }
                        }
                    }
                    else
                    {
                        // Existing bid not found
                        // So, Place a new one
                        Bid bid = _mapper.Map<Bid>(command);
                        ad.Bids.Append(bid);

                        // Place bid in Advertisements
                        var updateAd = Builders<Advertisement>.Update.Set(a => a.Bids, ad.Bids);
                        var res = await _context.Advertisements.UpdateOneAsync(adFilter, updateAd, null, cancellationToken);
                        if (res.IsAcknowledged != true)
                        {
                            // Update not acknowledged, so abort
                            _logger.LogInformation("Adding Bid in Advertisement : {AdvertismenetId} by User : {UserId} failed because update is not acknowledged", command.AdvertisementId, command.UserId);
                            await session.AbortTransactionAsync(cancellationToken);
                            return null;
                        }

                        // Add Bid in Bids

                        userBidFilter = Builders<Bid>.Filter.Eq("UserId", command.UserId);
                        adBidFilter = Builders<Bid>.Filter.Eq("AdvertisementId", command.AdvertisementId);

                        await _context.Bids.InsertOneAsync(bid, null, cancellationToken);
                        _logger.LogInformation("Placed Bid successfully for Advertisement : {AdvertismenetId} by User : {UserId}", command.AdvertisementId, command.UserId);
                    }

                    await session.CommitTransactionAsync(cancellationToken);
                }
                catch
                {
                    await session.AbortTransactionAsync(cancellationToken);
                }
            }
            return await (await _context.Bids.FindAsync(userBidFilter & adBidFilter, null, cancellationToken)).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> RemoveBid(RemoveBidCommand command, CancellationToken cancellationToken = default)
        {
            var adFilter = Builders<Advertisement>.Filter.Eq("_id", command.AdvertisementId);
            var userBidFilter = Builders<Bid>.Filter.Eq("UserId", command.UserId);
            var adBidFilter = Builders<Bid>.Filter.Eq("AdvertisementId", command.AdvertisementId);


            Advertisement ad = await (await _context.Advertisements.FindAsync(adFilter, null, cancellationToken)).FirstOrDefaultAsync(cancellationToken);

            if (ad == null)
            {
                _logger.LogInformation("Unable to remove bid for Advertisement : {AdvertisementId} by User : {UserId} as the advertisement is not found", command.AdvertisementId, command.UserId);
                return false;
            }

            // At this point, we are sure that the advertisement exists
            using (var session = await _context.Client.StartSessionAsync())
            {
                // Begin transaction
                session.StartTransaction();
                try
                {
                    // Did user have an bid?
                    int existingAdBidIndex = ad.Bids.FindIndex(a => a.UserId == command.UserId);
                    if (existingAdBidIndex != -1)
                    {
                        _logger.LogInformation("Found existing bid while placing bid for Advertisement : {AdvertisementId} by User : {UserId}", command.AdvertisementId, command.UserId);
                        ad.Bids.RemoveAt(existingAdBidIndex);
                        var updateAd = Builders<Advertisement>.Update.Set(a => a.Bids, ad.Bids);
                        
                        var resUpdate = await _context.Advertisements.UpdateOneAsync(adFilter, updateAd, null, cancellationToken);
                        if (resUpdate.IsAcknowledged != true)
                        {
                            // Update not acknowledged, so abort
                            _logger.LogInformation("Removing Bid from Advertisements collection for Advertisement : {AdvertismenetId} by User : {UserId} failed because update is not acknowledged", command.AdvertisementId, command.UserId);
                            await session.AbortTransactionAsync(cancellationToken);
                            return false;
                        }

                        // Remove from Bids as well
                        var bidUserFilter = Builders<Bid>.Filter.Eq("UserId", command.UserId);
                        var bidAdFilter = Builders<Bid>.Filter.Eq("AdvertisementFilter", command.AdvertisementId);
                        
                        var resDelete = await _context.Bids.DeleteOneAsync(bidUserFilter & bidAdFilter, null, cancellationToken);
                        if (resDelete.IsAcknowledged != true)
                        {
                            // Delete not acknowledged, so abort
                            _logger.LogInformation("Deleting Bid from Bids collection for Advertisement : {AdvertismenetId} by User : {UserId} failed because delete is not acknowledged", command.AdvertisementId, command.UserId);
                            await session.AbortTransactionAsync(cancellationToken);
                            return false;
                        }
                    }
                    else
                    {
                        // Existing bid not found
                        await session.CommitTransactionAsync(cancellationToken);
                        _logger.LogInformation("Unable to delete Bid for Advertisement : {AdvertismenetId} by User : {UserId}, Bid not found", command.AdvertisementId, command.UserId);
                        return false;
                    }
                    await session.CommitTransactionAsync(cancellationToken);
                }
                catch
                {
                    await session.AbortTransactionAsync(cancellationToken);
                }
            }
            return true;
        }

        public async Task<Bid> UpdateBid(UpdateBidCommand command, CancellationToken cancellationToken = default)
        {

            var adFilter = Builders<Advertisement>.Filter.Eq("_id", command.AdvertisementId);
            var userBidFilter = Builders<Bid>.Filter.Eq("UserId", command.UserId);
            var adBidFilter = Builders<Bid>.Filter.Eq("AdvertisementId", command.AdvertisementId);


            Advertisement ad = await (await _context.Advertisements.FindAsync(adFilter, null, cancellationToken)).FirstOrDefaultAsync(cancellationToken);

            if (ad == null)
            {
                _logger.LogInformation("Unable to place bif for Advertisement : {AdvertisementId} by User : {UserId} as the advertisement is not found", command.AdvertisementId, command.UserId);
                return null;
            }

            // At this point, we are sure that the advertisement exists
            using (var session = await _context.Client.StartSessionAsync())
            {
                // Begin transaction
                session.StartTransaction();
                try
                {
                    // Did user already have an existing bid?
                    // If so update it
                    int existingAdBidIndex = ad.Bids.FindIndex(a => a.UserId == command.UserId);
                    if (existingAdBidIndex != -1)
                    {
                        _logger.LogInformation("Found existing bid while placing bid for Advertisement : {AdvertisementId} by User : {UserId}", command.AdvertisementId, command.UserId);
                        // Only update oif there is a change
                        if (ad.Bids[existingAdBidIndex].Price != command.Price)
                        {
                            ad.Bids[existingAdBidIndex].Price = command.Price;
                            var updateAd = Builders<Advertisement>.Update.Set(a => a.Bids, ad.Bids);
                            var res = await _context.Advertisements.UpdateOneAsync(adFilter, updateAd, null, cancellationToken);
                            if (res.IsAcknowledged != true)
                            {
                                // Update not acknowledged, so abort
                                _logger.LogInformation("Updating Bid in Advertisement : {AdvertismenetId} by User : {UserId} failed because update is not acknowledged", command.AdvertisementId, command.UserId);
                                await session.AbortTransactionAsync(cancellationToken);
                                return null;
                            }

                            // Update in Bids as well
                            var bidUserFilter = Builders<Bid>.Filter.Eq("UserId", command.UserId);
                            var bidAdFilter = Builders<Bid>.Filter.Eq("AdvertisementFilter", command.AdvertisementId);
                            var updateBid = Builders<Bid>.Update
                                .Set(b => b.Price, command.Price)
                                .Set(a => a.UpdatedBy, command.UserId)
                                .Set(a => a.UpdatedAt, DateTime.Now)
                                .Set(a => a.UpdatedPublished, false);
                            res = await _context.Bids.UpdateOneAsync(bidUserFilter & bidAdFilter, updateBid, null, cancellationToken);
                            if (res.IsAcknowledged != true)
                            {
                                // Update not acknowledged, so abort
                                _logger.LogInformation("Updating Bid in Bids collection for Advertisement : {AdvertismenetId} by User : {UserId} failed because update is not acknowledged", command.AdvertisementId, command.UserId);
                                await session.AbortTransactionAsync(cancellationToken);
                                return null;
                            }
                        }
                    }
                    else
                    {
                        // Existing bid not found
                        await session.CommitTransactionAsync(cancellationToken);
                        _logger.LogInformation("Unable to Update Bid for Advertisement : {AdvertismenetId} by User : {UserId}, Bid not found", command.AdvertisementId, command.UserId);
                        return null;
                    }

                    await session.CommitTransactionAsync(cancellationToken);
                }
                catch
                {
                    await session.AbortTransactionAsync(cancellationToken);
                }
            }
            return await (await _context.Bids.FindAsync(userBidFilter & adBidFilter, null, cancellationToken)).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
