using GitHubUserActivity.Models;

namespace GitHubUserActivity.Interfaces;

public interface IEventFormatter
{
    string FormatEvent(GitHubEvent gitHubEvent);
}