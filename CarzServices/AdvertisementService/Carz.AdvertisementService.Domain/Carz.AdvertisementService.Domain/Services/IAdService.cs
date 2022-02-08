using Carz.AdvertisementService.Domain.Commands.Advertisement;
using Carz.AdvertisementService.Domain.Entities;
using Carz.AdvertisementService.Domain.Queries.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Domain.Services
{
    public interface IAdService
    {
        Task<bool> BlockAd(BlockAdCommand command, CancellationToken token);
        Task<bool> CloseAd(CloseAdCommand command, CancellationToken token);
        Task<Advertisement> CreateAd(CreateAdCommand command, CancellationToken token);
        Task<bool> DisableAd(DisableAdCommand command, CancellationToken token);
        Task<bool> EnableAd(EnableAdCommand command, CancellationToken token);
        Task<List<Advertisement>> GetActiveAdsForUser(GetActiveAdsForUserQuery query, CancellationToken token);
        Task<List<Advertisement>> GetActiveAds(GetActiveAdsQuery query, CancellationToken token);
        Task<List<Advertisement>> GetAdsForUser(GetAdsForUserQuery query, CancellationToken token);
        Task<List<Advertisement>> GetAllAds(GetAllAdsQuery query, CancellationToken token);
        Task<List<Advertisement>> GetBlockedAdsForUser(GetBlockedAdsForUserQuery query, CancellationToken token);
        Task<List<Advertisement>> GetBlockedAds(GetBlockedAdsQuery query, CancellationToken token);
        Task<List<Advertisement>> GetClosedAdsForUser(GetClosedAdsForUserQuery query, CancellationToken token);
        Task<List<Advertisement>> GetClosedAds(GetClosedAdsQuery query, CancellationToken token);
        Task<List<Advertisement>> GetDisabledAdsForUser(GetDisabledAdsForUserQuery query, CancellationToken token);
        Task<List<Advertisement>> GetDisabledAds(GetDisabledAdsQuery query, CancellationToken token);
        Task<Advertisement> UpdateAd(UpdateAdCommand command, CancellationToken token);
    }
}
