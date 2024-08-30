using System.Net.Http.Json;
using GitHubUserActivity.Interfaces;
using GitHubUserActivity.Models;

namespace GitHubUserActivity.Services;

public class GitHubEventService : IGitHubEventService
{
    private readonly HttpClient _client;
    private const string GitHubApiBaseUrl = "https://api.github.com/users/";

    public GitHubEventService(HttpClient client)
    {
        _client = client;
        _client.DefaultRequestHeaders.UserAgent.ParseAdd("CSharpApp");
    }

    public async Task<List<GitHubEvent>> GetUserEventsAsync(string? username, CancellationToken cancellationToken)
    {
        var url = $"{GitHubApiBaseUrl}{username}/events";
        return await _client.GetFromJsonAsync<List<GitHubEvent>>(url, cancellationToken) ?? new List<GitHubEvent>();
    }
}