using System.Text.Json;
using GitHubUserActivity.Interfaces;
using GitHubUserActivity.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GitHubUserActivity;

class Program
{
    private const int MaxEventsToDisplay = 20;

    static async Task Main(string[] args)
    {
        // Configuración de DI
        var serviceProvider = new ServiceCollection()
            .AddSingleton<HttpClient>(provider => new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(10)
            })
            .AddSingleton<IGitHubEventService, GitHubEventService>()
            .AddSingleton<IEventFormatter, EventFormatter>()
            .AddSingleton<InputValidator>()
            .AddSingleton<DisplayService>()
            .BuildServiceProvider();

        var inputValidator = serviceProvider.GetService<InputValidator>();

        Console.Write("Please enter the GitHub username: ");
        string? username = Console.ReadLine();

        if (inputValidator != null && !inputValidator.ValidateUsername(username))
        {
            Console.WriteLine("Username cannot be empty. Please run the program again and enter a valid username.");
            return;
        }

        var gitHubEventService = serviceProvider.GetService<IGitHubEventService>();
        var displayService = serviceProvider.GetService<DisplayService>();

        if (gitHubEventService == null || displayService == null) return;

        try
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var events = await gitHubEventService.GetUserEventsAsync(username, cancellationTokenSource.Token);
            displayService.DisplayUserEvents(username, events, MaxEventsToDisplay);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("Error fetching data from GitHub: " + e.Message);
        }
        catch (TaskCanceledException e)
        {
            Console.WriteLine("Request timed out: " + e.Message);
        }
        catch (JsonException e)
        {
            Console.WriteLine("Error parsing JSON data: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("An unexpected error occurred: " + e.Message);
        }
    }
}
