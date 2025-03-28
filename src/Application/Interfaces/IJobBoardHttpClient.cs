using Domain.Entities;

namespace Application.Interfaces;
public interface IJobBoardHttpClient
{
    Task<List<JobAd>> GetJobsAsync();
}
