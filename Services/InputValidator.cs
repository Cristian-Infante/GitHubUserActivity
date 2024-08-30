namespace GitHubUserActivity.Services;

public class InputValidator
{
    public bool ValidateUsername(string? username)
    {
        return !string.IsNullOrWhiteSpace(username);
    }
}