namespace Infrastructure.Services;
public abstract class BaseJobBoardHttpClient(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    protected async Task<HttpContent> GetJobsAsync(string url)
    {
        HttpResponseMessage response = await _httpClient.GetAsync("?&sortBy=published&orderBy=DESC&perPage=100&salaryCurrencies=PLN&page=" + url); // nie może być w base url, bo nie działa

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.StatusCode.ToString() + "  " + response.Content.ToString());
        }

        return response.Content;
    }
}
