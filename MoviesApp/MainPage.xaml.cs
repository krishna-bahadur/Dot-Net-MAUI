using MoviesApp.Services;
using MoviesApp.ViewModels;

namespace MoviesApp;

public partial class MainPage : ContentPage
{
    private readonly MovieService _movieService;
	public MainPage()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        _movieService = new MovieService();
        LoadMovies();
    }

    private async void LoadMovies()
    {
        var nowPlaying = await _movieService.GetNowPlayingMoviesAsync();
        var popular = await _movieService.GetPopularMoviesAsync();
        var topRated = await _movieService.GetTopRatedMoviesAsync();
        var upcoming = await _movieService.GetUpcomingMoviesAsync();
        var trending = await _movieService.GetTrendingMoviesAsync();

        nowPlayingMoviesCollection.ItemsSource = nowPlaying;
        popularMoviesCollection.ItemsSource = popular;
        topRatedMoviesCollection.ItemsSource = topRated;
        upcommingMoviesCollection.ItemsSource = upcoming;
        trendingMoviesCollection.ItemsSource = trending;
    }

    private async void OnMovieTapped(object sender, EventArgs e)
    {
        var frame = (Frame)sender;
        var movie = (MovieVM)frame.BindingContext;

        if(movie == null)
        {
            return;
        }

        await Navigation.PushAsync(new MovieDetailPage(movie));
    }

    private async void OnLinkTapped(object sender, EventArgs e)
    {
        await Launcher.OpenAsync(new Uri("https://developer.themoviedb.org"));
    }
}

