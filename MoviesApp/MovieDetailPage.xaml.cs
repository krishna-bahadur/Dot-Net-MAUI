using MoviesApp.Services;
using MoviesApp.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MoviesApp;

public partial class MovieDetailPage : ContentPage, INotifyPropertyChanged
{
    private readonly MovieService _movieService;
    private int _movieId;
    private bool _isLoading;

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            if(_isLoading != value)
            {
                _isLoading =value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNotLoading));
            }
        }
    }
    public bool IsNotLoading => !_isLoading;

    public MovieDetailPage(MovieVM movie)
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        _movieService = new MovieService();
        _movieId = movie.Id;
        BindingContext = this;
        LoadMovieDetails();
    }

    private async void LoadMovieDetails()
    {
        IsLoading = true;

        try
        {
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

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


}