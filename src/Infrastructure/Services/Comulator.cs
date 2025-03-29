using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Services;
public class JustJoinItJobBoardComulator(IJustJoinItJobBoardHttpClient httpClient) : IComulator
{
    public async Task<List<JobAd>> Comulate(Action<RequestOptions> ConfigureOptions)
    {
        List<JobAd> justJoinItJobs = new List<JobAd>();
        ConfigureOptions(_options);
        
        for (long page = _options.StartPage; page <= _options.EndPage; page++)
        {
            justJoinItJobs.AddRange(await _httpClient.GetJobsAsync(page));
        }

        return justJoinItJobs;
    }

    private readonly IJustJoinItJobBoardHttpClient _httpClient = httpClient;
    private readonly RequestOptions _options = new RequestOptions { StartPage = 1, EndPage = 1 };
}