using GitHubUserActivity.Interfaces;
using GitHubUserActivity.Models;

namespace GitHubUserActivity.Services;

public class EventFormatter : IEventFormatter
{
    public string FormatEvent(GitHubEvent gitHubEvent)
    {
        var repoName = gitHubEvent.Repository?.Name ?? "Unknown repository";
        return $"{gitHubEvent.CreatedAt:yyyy-MM-dd HH:mm:ss} - {gitHubEvent.Type} in {repoName}";
    }
}