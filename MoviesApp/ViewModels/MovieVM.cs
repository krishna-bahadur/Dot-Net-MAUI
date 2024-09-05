using Newtonsoft.Json;
using System.ComponentModel;

namespace MoviesApp.ViewModels;

public class MovieVM 
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    [JsonProperty("poster_path")]
    public string PosterPath { get; set; } = string.Empty;
    public string Overview { get; set; } = string.Empty;
    [JsonProperty("release_date")]
    public string ReleaseDate { get; set; } = string.Empty;
    public List<Genre> Genres { get; set; } = new List<Genre>();
    [JsonProperty("vote_average")]
    public decimal Rating { get; set; } 
    public string Runtime { get; set; } = string.Empty;
    public string Revenue { get; set; } = string.Empty;
    public string Budget { get; set; } = string.Empty;

    public List<Cast> Casts { get; set; } = new List<Cast>();
    // Computed property to get the full image URL
    public string FullPosterUrl => string.IsNullOrEmpty(PosterPath)
        ? ""
        : $"https://image.tmdb.org/t/p/w500{PosterPath}";

}

public class Genre
{
    public string Name { get; set; } = string.Empty;
}

public class Cast
{
    public string Name { get; set; } = string.Empty;
    [JsonProperty("profile_path")]
    public string ProfilePath { get; set; } = string.Empty;

    public string FullProfilePathUrl => string.IsNullOrEmpty(ProfilePath)
        ? ""
        : $"https://image.tmdb.org/t/p/w500{ProfilePath}";
}