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
        //Show skeleton views
        nowPlayingSkeletonView.IsVisible=true;
        nowPlayingMoviesCollection.IsVisible = false;
        
        popularSkeletonView.IsVisible=true;
        popularMoviesCollection.IsVisible = false;
        
        upcomingSkeletonView.IsVisible=true;
        upcommingMoviesCollection.IsVisible = false;


        var nowPlaying = await _movieService.GetNowPlayingMoviesAsync();
        var popular = await _movieService.GetPopularMoviesAsync();
        var topRated = await _movieService.GetTopRatedMoviesAsync();
        var upcoming = await _movieService.GetUpcomingMoviesAsync();
        var trending = await _movieService.GetTrendingMoviesAsync();

        nowPlayingMoviesCollection.ItemsSource = nowPlaying;
        nowPlayingSkeletonView.IsVisible = false;
        nowPlayingMoviesCollection.IsVisible = true;

        upcommingMoviesCollection.ItemsSource = upcoming;
        trendingMoviesCollection.ItemsSource = trending;

        popularMoviesCollection.ItemsSource = popular;
        popularSkeletonView.IsVisible = false;
        popularMoviesCollection.IsVisible = true;

        topRatedMoviesCollection.ItemsSource = topRated;
        upcomingSkeletonView.IsVisible = false;
        upcommingMoviesCollection.IsVisible = true;
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

