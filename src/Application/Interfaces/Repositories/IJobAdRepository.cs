using Domain.Entities;

namespace Application.Interfaces.Repositories;
public interface IJobAdRepository
{
    public Task InsertJobAds(List<JobAd> jobAds);
    public IEnumerable<JobAd> GetJobAds(IEnumerable<string> companyNames);
}
