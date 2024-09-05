using MoviesApp.Services;
using MoviesApp.ViewModels;

namespace MoviesApp;

public partial class MovieDetailPage : ContentPage
{
    private readonly MovieService _movieService;
    private int _movieId;
    public bool IsLoading { get; set; } = true;
    public MovieDetailPage(MovieVM movie)
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        _movieService = new MovieService();
        _movieId = movie.Id;
        LoadMovieDetails();
    }

    private async void LoadMovieDetails()
    {
        try
        {
            IsLoading = true; // Show ActivityIndicator

            var movieDetail = await _movieService.GetMovieDetailAsync(_movieId);

            //Change Release date
            if (!string.IsNullOrEmpty(movieDetail.ReleaseDate))
            {
                var releaseYear = movieDetail.ReleaseDate.Split('-')[0];
                movieDetail.ReleaseDate = releaseYear;
            }

            var casts = await _movieService.GetMovieCreditAsync(_movieId);
            movieDetail.Casts = casts;

            BindingContext = movieDetail;
        }
        catch(Exception ex)
        {
            Console.Write(ex.Message.ToString());
        }
        finally
        {
            IsLoading = false;
        }
    }
}