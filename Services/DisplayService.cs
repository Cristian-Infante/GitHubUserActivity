using GitHubUserActivity.Interfaces;
using GitHubUserActivity.Models;

namespace GitHubUserActivity.Services;

public class DisplayService
{
    private readonly IEventFormatter _eventFormatter;

    public DisplayService(IEventFormatter eventFormatter)
    {
        _eventFormatter = eventFormatter;
    }

    public void DisplayUserEvents(string? username, List<GitHubEvent> events, int maxEventsToDisplay)
    {
        if (events.Count == 0)
        {
            Console.WriteLine("No recent activity found for this user.");
            return;
        }

        Console.WriteLine($"\nRecent activity for {username}:");
        foreach (var gitHubEvent in events.Take(maxEventsToDisplay)) // Limitamos a 'maxEventsToDisplay' eventos para evitar sobrecargar la consola
        {
            var formattedEvent = _eventFormatter.FormatEvent(gitHubEvent);
            Console.WriteLine(formattedEvent);
        }
    }
}

