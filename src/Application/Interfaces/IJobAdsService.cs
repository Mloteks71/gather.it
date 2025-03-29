using Domain.Entities;

namespace Application.Interfaces
{
    public interface IJobAdsService
    {
        public Task Save(List<JobAd> jobAds, CancellationToken cancellationToken);
    }
}
