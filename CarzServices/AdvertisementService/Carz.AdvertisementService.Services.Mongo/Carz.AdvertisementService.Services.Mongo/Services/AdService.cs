using Carz.AdvertisementService.Domain.Commands.Advertisement;
using Carz.AdvertisementService.Domain.Entities;
using Carz.AdvertisementService.Domain.Queries.Advertisement;
using Carz.AdvertisementService.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Services.Mongo.Services
{
    public class AdService : IAdService
    {
        public Task<bool> BlockAd(BlockAdCommand command, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CloseAd(CloseAdCommand command, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Advertisement> CreateAd(CreateAdCommand command, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DisableAd(DisableAdCommand command, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EnableAd(EnableAdCommand command, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> GetActiveAds(GetActiveAdsQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> GetActiveAdsForUser(GetActiveAdsForUserQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> GetAdsForUser(GetAdsForUserQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> GetAllAds(GetAllAdsQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> GetBlockedAds(GetBlockedAdsQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> GetBlockedAdsForUser(GetBlockedAdsForUserQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> GetClosedAds(GetClosedAdsQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> GetClosedAdsForUser(GetClosedAdsForUserQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> GetDisabledAds(GetDisabledAdsQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> GetDisabledAdsForUser(GetDisabledAdsForUserQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Advertisement> UpdateAd(UpdateAdCommand command, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
