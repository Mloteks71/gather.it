using Application.Dtos.JustJoinIt;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Infrastructure.Services;
public class JustJoinItJobBoardHttpClient : BaseJobBoardHttpClient, IJustJoinItJobBoardHttpClient
{
    private readonly HttpClient _httpClient;

    public JustJoinItJobBoardHttpClient(HttpClient httpClient, IConfiguration config) : base(httpClient)
    {
        _httpClient = httpClient;

        httpClient.BaseAddress = new(config["JustJoinIt:Url"]!);
        httpClient.DefaultRequestHeaders.Add("Version", "2");
    }

    public async Task<List<JobAd>> GetJobsAsync()
    {

        HttpContent content = await base.GetJobsAsync("1");

        var test = await content.ReadAsStringAsync();

        JustJoinItResponse? justJoinItResponse = await content.ReadFromJsonAsync<JustJoinItResponse>();

        if (justJoinItResponse == null)
        {
            throw new Exception("JustJoinIt response empty.");
        }

        return justJoinItResponse.CreateDtos();

    }
}
