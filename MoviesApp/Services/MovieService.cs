using MoviesApp.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MoviesApp.Services;

public class MovieService
{
    private const string _accessToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyOWU5YjA0MDFjYmJhZGYwZDA4NTBiMzRiOTZhOWYyZSIsIm5iZiI6MTcyNTI3NTMwOS43NDk5NCwic3ViIjoiNjZkNTliMzdhM2M5OTU3MDJhNDViNjU4Iiwic2NvcGVzIjpbImFwaV9yZWFkIl0sInZlcnNpb24iOjF9.ia7tKoyVDdT6NyZZUqRPLhgCd1T0OxL9o6kI2LYD3-Y";
    private const string BaseUrl = "https://api.themoviedb.org/3/";
    private readonly HttpClient _httpClient;

    public MovieService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(BaseUrl);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
    }

    // Now playing movies
    public async Task<List<MovieVM>> GetNowPlayingMoviesAsync() => await GetMoviesAsync("movie/now_playing");
    public async Task<List<MovieVM>> GetPopularMoviesAsync() => await GetMoviesAsync("movie/popular");
    public async Task<List<MovieVM>> GetTopRatedMoviesAsync() => await GetMoviesAsync("movie/top_rated");
    public async Task<List<MovieVM>> GetUpcomingMoviesAsync() => await GetMoviesAsync("movie/upcoming");
    public async Task<List<MovieVM>> GetTrendingMoviesAsync() => await GetMoviesAsync("trending/movie/week");
    public async Task<MovieVM> GetMovieDetailAsync(int id) => await GetMovieDetailAsync($"movie/{id}");

    private async Task<List<MovieVM>> GetMoviesAsync(string endpoint)
    {
        var response = await _httpClient.GetAsync($"{endpoint}?language=en-US&page=1");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<MovieResponse>(json);
        return result?.Results ?? new List<MovieVM>();
    }
    private async Task<MovieVM> GetMovieDetailAsync(string endpoint)
    {
        var response = await _httpClient.GetAsync($"{endpoint}?language=en-US&page=1");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<MovieVM>(json);
        return result ?? new MovieVM();
    }
    public async Task<List<Cast>> GetMovieCreditAsync(int movie_id)
    {
        var response = await _httpClient.GetAsync($"movie/{movie_id}/credits?language=en-US&page=1");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<CastResponse>(json);
        return result.Cast ?? new List<Cast>();
    }

    public class MovieResponse
    {
        [JsonProperty("results")]
        public List<MovieVM> Results { get; set; }
    }
    public class CastResponse
    {
        [JsonProperty("cast")]
        public List<Cast> Cast { get; set; }
    }

}
