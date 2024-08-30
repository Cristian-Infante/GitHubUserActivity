# GitHubUserActivity

This project is a command-line application written in C# that allows users to retrieve and display the recent activity of any GitHub user. The application uses the GitHub API to fetch recent events, such as commits, repository creations, and other types of activities.

## Project Structure

The application follows SOLID and GRASP design principles to ensure modular, maintainable, and easily extensible code. Below is an overview of the main components of the project:

### Main Files and Folders

- **`Program.cs`**: Contains the entry point of the application. It is responsible for setting up dependency injection, handling user input, and coordinating the interaction between the various services.
- **`Interfaces/`**: Folder containing interface definitions that are implemented by services.
  - **`IEventFormatter.cs`**: Interface for formatting GitHub events into a user-readable string.
  - **`IGitHubEventService.cs`**: Interface for fetching recent GitHub events for a specific user.
- **`Models/`**: Folder containing classes that represent the data retrieved from the GitHub API.
  - **`GitHubEvent.cs`**: Class representing a GitHub event. It includes properties such as the event type (`type`), the associated repository (`repository`), and the creation date (`created_at`).
  - **`Repository.cs`**: Class representing a GitHub repository. It includes the repository name (`name`).
- **`Services/`**: Folder that contains classes encapsulating the business logic of the application.
  - **`GitHubEventService.cs`**: Service responsible for making HTTP requests to the GitHub API to retrieve the user's recent activity. It handles the connection to the API and returns the parsed data.
  - **`DisplayService.cs`**: Service that handles the display of data in the console in an organized manner. It uses the `EventFormatter` to format the events before displaying them.
  - **`InputValidator.cs`**: Service that validates user input (the GitHub username).
  - **`EventFormatter.cs`**: Service responsible for formatting GitHub events into a user-readable string.

## Main Components

1. `GitHubEventService`  
This class implements the `IGitHubEventService` interface and is responsible for performing HTTP requests to the GitHub API to retrieve a user's recent events. It uses an `HttpClient` configured with a specific `User-Agent` to avoid issues when interacting with the GitHub API. The base URL of the GitHub API is stored as a constant to avoid hardcoding.
2. `DisplayService`  
This service handles the display of events fetched from GitHub in the console. It uses an `IEventFormatter` implementation to format the events before displaying them. The number of events shown can be limited by specifying a maximum number (`MaxEventsToDisplay`), making it configurable and preventing console overload.
3. `InputValidator`  
This service validates the user's input (GitHub username). It ensures that the username is not null or empty before proceeding to make the API request.
4. `EventFormatter`  
This service is responsible for formatting the GitHub events into a human-readable string format. It handles potential null values in the event data, ensuring that the output is always clear and informative.

## Dependency Injection

The application uses dependency injection through `Microsoft.Extensions.DependencyInjection` to manage the creation and lifecycle of services. This facilitates unit testing of individual components and improves code maintainability.

## Usage

To run the application, follow these steps:

1. Clone the repository to your local machine.
2. Ensure that you have .NET 6.0 SDK or later installed.
3. Navigate to the project folder and run the following command in the terminal:
   ```bash
   dotnet run
   ```
4. Enter the GitHub username when prompted.

The application will display the user's recent activity in the console.

## Sample Output

```plaintext
Please enter the GitHub username: <GitHub User>

Recent activity for <GitHub User>:
2024-08-28 20:55:10 - PushEvent in repository-name
2024-08-27 20:19:12 - CreateEvent in repository-name
2024-08-27 20:19:09 - CreateEvent in repository-name
2024-08-27 19:57:15 - PullRequestEvent in repository-name
```
