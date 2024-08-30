using System.Text.Json.Serialization;

namespace GitHubUserActivity.Models;

public class GitHubEvent
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("repo")]
    public Repository? Repository { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }
}