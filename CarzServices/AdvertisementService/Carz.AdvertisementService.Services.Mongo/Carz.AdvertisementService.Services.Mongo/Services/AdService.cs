using AutoMapper;
using Carz.AdvertisementService.Domain.Commands.Advertisement;
using Carz.AdvertisementService.Domain.Entities;
using Carz.AdvertisementService.Domain.Queries.Advertisement;
using Carz.AdvertisementService.Domain.Services;
using Carz.AdvertisementService.Services.Mongo.Contexts;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Services.Mongo.Services
{
    public class AdService : IAdService
    {
        private readonly ILogger<AdService> _logger;
        private readonly AdvertisementDbContext _context;
        private readonly IMapper _mapper;

        public AdService(ILogger<AdService> logger, AdvertisementDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> BlockAd(BlockAdCommand command, CancellationToken cancellationToken)
        {
            var filter = Builders<Advertisement>.Filter.Eq("_id", command.Id);
            var ad = await (await _context.Advertisements.FindAsync(filter, null, cancellationToken)).FirstOrDefaultAsync(cancellationToken);
            // Ad not exist
            if (ad == null)
            {
                _logger.LogInformation("Advertisement with Id : {AdvertisementId} not found for blocking", command.Id);
                return false;
            }

            // Already blocked
            if (ad.Blocked == true)
            {
                _logger.LogInformation("Tried blocking Advertisement with Id : {AdvertisementId} by User : {UserId} but it is already blocked", command.Id, command.PerformedBy);
                return false;
            }

            var update = Builders<Advertisement>.Update.Set(a => a.Blocked, true).Set(a => a.BlockedPublished, false);
            var updateResult = await _context.Advertisements.UpdateOneAsync(filter, update, null, cancellationToken);

            // Update acknowledged by MongoDb
            if (updateResult.IsAcknowledged == true)
            {
                // Success
                _logger.LogInformation("Advertisement with Id : {AdvertisementId} is blocked by User : {UserId}", command.Id, command.PerformedBy);
                return true;
            }

            // Update not acknowledged by MongoDb
            _logger.LogInformation("Tried blocking Advertisement with Id : {AdvertisementId} by User : {UserId} but result is not acknowledged", command.Id, command.PerformedBy);
            return false;
        }

        public async Task<bool> CloseAd(CloseAdCommand command, CancellationToken cancellationToken)
        {
            var filter = Builders<Advertisement>.Filter.Eq("_id", command.Id);
            var ad = await (await _context.Advertisements.FindAsync(filter, null, cancellationToken)).FirstOrDefaultAsync(cancellationToken);
            // Ad not exist
            if (ad == null)
            {
                _logger.LogInformation("Advertisement with Id : {AdvertisementId} not found for closeing", command.Id);
                return false;
            }

            // Already closed
            if (ad.Closed == true)
            {
                _logger.LogInformation("Tried closing Advertisement with Id : {AdvertisementId} by User : {UserId} but it is already closed", command.Id, command.ClosedBy);
                return false;
            }

            var update = Builders<Advertisement>.Update.Set(a => a.Closed, true).Set(a => a.ClosedPublished, false);
            var updateResult = await _context.Advertisements.UpdateOneAsync(filter, update, null, cancellationToken);

            // Update acknowledged by MongoDb
            if (updateResult.IsAcknowledged == true)
            {
                // Success
                _logger.LogInformation("Advertisement with Id : {AdvertisementId} is closed by User : {UserId}", command.Id, command.ClosedBy);
                return true;
            }

            // Update not acknowledged by MongoDb
            _logger.LogInformation("Tried closing Advertisement with Id : {AdvertisementId} by User : {UserId} but result is not acknowledged", command.Id, command.ClosedBy);
            return false;
        }

        public async Task<Advertisement> CreateAd(CreateAdCommand command, CancellationToken cancellationToken)
        {
            Advertisement ad = _mapper.Map<Advertisement>(command);
            await _context.Advertisements.InsertOneAsync(ad, null, cancellationToken);
            _logger.LogInformation("Created a new Advertisement by user : {UserId}", command.UserId);
            return ad;
        }

        public async Task<bool> DisableAd(DisableAdCommand command, CancellationToken cancellationToken)
        {
            var filter = Builders<Advertisement>.Filter.Eq("_id", command.Id);
            var ad = await (await _context.Advertisements.FindAsync(filter, null, cancellationToken)).FirstOrDefaultAsync(cancellationToken);
            // Ad not exist
            if (ad == null)
            {
                _logger.LogInformation("Advertisement with Id : {AdvertisementId} not found for closeing", command.Id);
                return false;
            }

            // Already disabled
            if (ad.Enabled == false)
            {
                _logger.LogInformation("Tried closeing Advertisement with Id : {AdvertisementId} by User : {UserId} but it is already disabled", command.Id, command.DisabledBy);
                return false;
            }

            var update = Builders<Advertisement>.Update.Set(a => a.Enabled, false).Set(a => a.DisabledPublished, false);
            var updateResult = await _context.Advertisements.UpdateOneAsync(filter, update, null, cancellationToken);

            // Update acknowledged by MongoDb
            if (updateResult.IsAcknowledged == true)
            {
                // Success
                _logger.LogInformation("Advertisement with Id : {AdvertisementId} is disabled by User : {UserId}", command.Id, command.DisabledBy);
                return true;
            }

            // Update not acknowledged by MongoDb
            _logger.LogInformation("Tried disabling Advertisement with Id : {AdvertisementId} by User : {UserId} but result is not acknowledged", command.Id, command.DisabledBy);
            return false;
        }

        public async Task<bool> EnableAd(EnableAdCommand command, CancellationToken cancellationToken)
        {
            var filter = Builders<Advertisement>.Filter.Eq("_id", command.Id);
            var ad = await (await _context.Advertisements.FindAsync(filter, null, cancellationToken)).FirstOrDefaultAsync(cancellationToken);
            // Ad not exist
            if (ad == null)
            {
                _logger.LogInformation("Advertisement with Id : {AdvertisementId} not found for closeing", command.Id);
                return false;
            }

            // Already enabled
            if (ad.Enabled == true)
            {
                _logger.LogInformation("Tried closeing Advertisement with Id : {AdvertisementId} by User : {UserId} but it is already enabled", command.Id, command.PerformedBy);
                return false;
            }

            var update = Builders<Advertisement>.Update.Set(a => a.Enabled, true).Set(a => a.EnabledPublished, false);
            var updateResult = await _context.Advertisements.UpdateOneAsync(filter, update, null, cancellationToken);

            // Update acknowledged by MongoDb
            if (updateResult.IsAcknowledged == true)
            {
                // Success
                _logger.LogInformation("Advertisement with Id : {AdvertisementId} is enabled by User : {UserId}", command.Id, command.PerformedBy);
                return true;
            }

            // Update not acknowledged by MongoDb
            _logger.LogInformation("Tried enabling Advertisement with Id : {AdvertisementId} by User : {UserId} but result is not acknowledged", command.Id, command.PerformedBy);
            return false;
        }

        public async Task<List<Advertisement>> GetActiveAds(GetActiveAdsQuery query, CancellationToken cancellationToken)
        {
            var enabledFilter = Builders<Advertisement>.Filter.Eq("Enabled", true);
            var nonClosedFilter = Builders<Advertisement>.Filter.Eq("Closed", false);
            var nonBlockedFilter = Builders<Advertisement>.Filter.Eq("Blocked", false);

            List<Advertisement> ads = await (await _context.Advertisements.FindAsync(enabledFilter & nonClosedFilter & nonBlockedFilter, null, cancellationToken)).ToListAsync();

            return ads;
        }

        public async Task<List<Advertisement>> GetActiveAdsForUser(GetActiveAdsForUserQuery query, CancellationToken cancellationToken)
        {
            var enabledFilter = Builders<Advertisement>.Filter.Eq("Enabled", true);
            var nonClosedFilter = Builders<Advertisement>.Filter.Eq("Closed", false);
            var nonBlockedFilter = Builders<Advertisement>.Filter.Eq("Blocked", false);
            var userFilter = Builders<Advertisement>.Filter.Eq("UserId", query.UserId);

            List<Advertisement> ads = await (await _context.Advertisements.FindAsync(enabledFilter & nonClosedFilter & nonBlockedFilter & userFilter, null, cancellationToken)).ToListAsync();

            return ads;
        }

        public async Task<List<Advertisement>> GetAdsForUser(GetAdsForUserQuery query, CancellationToken cancellationToken)
        {
            var userFilter = Builders<Advertisement>.Filter.Eq("UserId", query.UserId);

            List<Advertisement> ads = await (await _context.Advertisements.FindAsync(userFilter, null, cancellationToken)).ToListAsync();

            return ads;
        }

        public async Task<List<Advertisement>> GetAllAds(GetAllAdsQuery query, CancellationToken cancellationToken)
        {
            List<Advertisement> ads = await (await _context.Advertisements.FindAsync(new BsonDocument(), null, cancellationToken)).ToListAsync();

            return ads;
        }

        public async Task<List<Advertisement>> GetBlockedAds(GetBlockedAdsQuery query, CancellationToken cancellationToken)
        {
            var blockedFilter = Builders<Advertisement>.Filter.Eq("Blocked", true);

            List<Advertisement> ads = await (await _context.Advertisements.FindAsync(blockedFilter, null, cancellationToken)).ToListAsync();

            return ads;
        }

        public async Task<List<Advertisement>> GetBlockedAdsForUser(GetBlockedAdsForUserQuery query, CancellationToken cancellationToken)
        {
            var blockedFilter = Builders<Advertisement>.Filter.Eq("Blocked", true);
            var userFilter = Builders<Advertisement>.Filter.Eq("UserId", query.UserId);

            List<Advertisement> ads = await (await _context.Advertisements.FindAsync(blockedFilter & userFilter, null, cancellationToken)).ToListAsync();

            return ads;
        }

        public async Task<List<Advertisement>> GetClosedAds(GetClosedAdsQuery query, CancellationToken cancellationToken)
        {
            var closedFilter = Builders<Advertisement>.Filter.Eq("Closed", true);

            List<Advertisement> ads = await (await _context.Advertisements.FindAsync(closedFilter, null, cancellationToken)).ToListAsync();

            return ads;
        }

        public async Task<List<Advertisement>> GetClosedAdsForUser(GetClosedAdsForUserQuery query, CancellationToken cancellationToken)
        {
            var closedFilter = Builders<Advertisement>.Filter.Eq("Closed", true);
            var userFilter = Builders<Advertisement>.Filter.Eq("UserId", query.UserId);

            List<Advertisement> ads = await (await _context.Advertisements.FindAsync(closedFilter & userFilter, null, cancellationToken)).ToListAsync();

            return ads;
        }

        public async Task<List<Advertisement>> GetDisabledAds(GetDisabledAdsQuery query, CancellationToken cancellationToken)
        {
            var disabledFilter = Builders<Advertisement>.Filter.Eq("Disabled", true);

            List<Advertisement> ads = await (await _context.Advertisements.FindAsync(disabledFilter, null, cancellationToken)).ToListAsync();

            return ads;
        }

        public async Task<List<Advertisement>> GetDisabledAdsForUser(GetDisabledAdsForUserQuery query, CancellationToken cancellationToken)
        {
            var disabledFilter = Builders<Advertisement>.Filter.Eq("Disabled", true);
            var userFilter = Builders<Advertisement>.Filter.Eq("UserId", query.UserId);

            List<Advertisement> ads = await (await _context.Advertisements.FindAsync(disabledFilter & userFilter, null, cancellationToken)).ToListAsync();

            return ads;
        }

        public async Task<Advertisement> UpdateAd(UpdateAdCommand command, CancellationToken cancellationToken)
        {
            var filter = Builders<Advertisement>.Filter.Eq("_id", command.Id);

            Advertisement ad = await (await _context.Advertisements.FindAsync(filter, null, cancellationToken)).FirstOrDefaultAsync(cancellationToken);
            if (ad == null)
            {
                _logger.LogInformation("Advertisment : {AdvertisementId} is not found for update by User : {UserId}", command.Id, command.UpdatedBy);
                return null;
            }

            var update = Builders<Advertisement>.Update
                .Set(a => a.Description, command.Description)
                .Set(a => a.Status, command.Status)
                .Set(a => a.Ownership, command.Ownership)
                .Set(a => a.AskPrice, command.AskPrice)
                .Set(a => a.Variant, command.Variant)
                .Set(a => a.UpdatedBy, command.UpdatedBy)
                .Set(a => a.UpdatedAt, DateTime.Now)
                .Set(a => a.UpdatedPublished, false);

            var res = await _context.Advertisements.UpdateOneAsync(filter, update, null, cancellationToken);

            if (res.IsAcknowledged == true)
            {
                _logger.LogInformation("Advertisment : {AdvertisementId} is updated by User : {UserId}", command.Id, command.UpdatedBy);
                return await (await _context.Advertisements.FindAsync(filter, null, cancellationToken)).FirstOrDefaultAsync(cancellationToken);
            }
            _logger.LogInformation("Tried updating Advertisment : {AdvertisementId} by User : {UserId} but update not acknowledged by MongoDb", command.Id, command.UpdatedBy);
            return null;
        }
    }
}
