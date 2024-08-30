using System.Text.Json.Serialization;

namespace GitHubUserActivity.Models;

public class Repository
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}