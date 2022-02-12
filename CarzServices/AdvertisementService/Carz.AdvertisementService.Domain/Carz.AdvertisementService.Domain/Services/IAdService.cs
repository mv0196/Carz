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
        Task<bool> BlockAd(BlockAdCommand command, CancellationToken cancellationToken);
        Task<bool> CloseAd(CloseAdCommand command, CancellationToken cancellationToken);
        Task<Advertisement> CreateAd(CreateAdCommand command, CancellationToken cancellationToken);
        Task<bool> DisableAd(DisableAdCommand command, CancellationToken cancellationToken);
        Task<bool> EnableAd(EnableAdCommand command, CancellationToken cancellationToken);
        Task<List<Advertisement>> GetActiveAdsForUser(GetActiveAdsForUserQuery query, CancellationToken cancellationToken);
        Task<List<Advertisement>> GetActiveAds(GetActiveAdsQuery query, CancellationToken cancellationToken);
        Task<List<Advertisement>> GetAdsForUser(GetAdsForUserQuery query, CancellationToken cancellationToken);
        Task<List<Advertisement>> GetAllAds(GetAllAdsQuery query, CancellationToken cancellationToken);
        Task<List<Advertisement>> GetBlockedAdsForUser(GetBlockedAdsForUserQuery query, CancellationToken cancellationToken);
        Task<List<Advertisement>> GetBlockedAds(GetBlockedAdsQuery query, CancellationToken cancellationToken);
        Task<List<Advertisement>> GetClosedAdsForUser(GetClosedAdsForUserQuery query, CancellationToken cancellationToken);
        Task<List<Advertisement>> GetClosedAds(GetClosedAdsQuery query, CancellationToken cancellationToken);
        Task<List<Advertisement>> GetDisabledAdsForUser(GetDisabledAdsForUserQuery query, CancellationToken cancellationToken);
        Task<List<Advertisement>> GetDisabledAds(GetDisabledAdsQuery query, CancellationToken cancellationToken);
        Task<Advertisement> UpdateAd(UpdateAdCommand command, CancellationToken cancellationToken);
    }
}
