using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Services;
public class Comulator(IJustJoinItJobBoardHttpClient httpClient) : IComulator
{
    private readonly IJustJoinItJobBoardHttpClient _httpClient = httpClient;

    public async Task<List<JobAd>> Comulate()
    {
        List<JobAd> justJoinItJobs = await _httpClient.GetJobsAsync();

        return justJoinItJobs;
    }
}