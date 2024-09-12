using MoviesApp.Services;
using MoviesApp.ViewModels;

namespace MoviesApp;

public partial class SearchResultsPage : ContentPage
{
    private readonly MovieService _movieService;
    private string _query;

    public SearchResultsPage(string query)
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        _movieService = new MovieService();
        _query = query;
        LoadSearchResults();
    }

    private async void LoadSearchResults()
    {
        var searchResults = await _movieService.SearchMovies(_query);
        searchResultMovies.ItemsSource = searchResults;
    }

    private async void OnMovieTapped(object sender, EventArgs e)
    {
        var frame = (Frame)sender;
        var movie = (MovieVM)frame.BindingContext;

        if (movie == null)
        {
            return;
        }

        await Navigation.PushAsync(new MovieDetailPage(movie));
    }
}