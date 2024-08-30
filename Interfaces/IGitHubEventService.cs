using GitHubUserActivity.Models;

namespace GitHubUserActivity.Interfaces;

public interface IGitHubEventService
{
    Task<List<GitHubEvent>> GetUserEventsAsync(string? username, CancellationToken cancellationToken);
}