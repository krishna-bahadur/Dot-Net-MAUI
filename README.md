# Movieinfo

**Movieinfo** is a .NET 8 MAUI application designed to provide a seamless experience for movie enthusiasts. It displays information about movies including those that are now playing, popular, upcoming, top-rated, and more. Users can also search for movies and view detailed information about them, including trailers.

## Features

- **Now Playing**: See the latest movies currently in theaters.
- **Popular**: Explore movies that are trending and widely watched.
- **Upcoming**: Get a sneak peek of movies that will be released soon.
- **Top Rated**: Discover the highest-rated movies based on user reviews.
- **Movie Details**: Access detailed information about each movie, including plot summaries and trailers.
- **Search Functionality**: Search for movies by name to find specific films quickly.

## Note

This app was created for learning purposes to explore and understand .NET MAUI. It is a demonstration of how to use MAUI for building cross-platform applications with movie-related features.

## How It Works

The app uses the [TMDB API](https://www.themoviedb.org) to fetch movie data. The TMDB API provides comprehensive movie details, including posters, trailers, and ratings. 

### TMDB API

- **API Base URL**: `https://api.themoviedb.org/3/`
- **API Key**: The application uses a free API/Access key provided by TMDB to access the data.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download) installed
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or later with MAUI workload
- [TMDB API/Access Key](https://www.themoviedb.org/documentation/api) (set up your own key if needed)

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/krishna-bahadur/Dot-Net-MAUI.git
    ```

2. Navigate to the project directory:

    ```bash
    cd MoviesApp
    ```

3. Restore the NuGet packages:

    ```bash
    dotnet restore
    ```

4. Build and run the application:

    ```bash
    dotnet build
    dotnet run
    ```

## Configuration

- **API Key**: Update your TMDB API/AccessKey key in the configuration file if needed. This file is located in Services\MovieService.
- **Splash Screen**: Customize the splash screen and app icons in the `Resources` folder.

## Contributing

Contributions are welcome! Please fork the repository and submit pull requests with your changes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

## Acknowledgments

- **[TMDB API](https://www.themoviedb.org)**: For providing free movie data and API access.
- **[.NET 8 MAUI](https://learn.microsoft.com/en-us/dotnet/maui/)**: For the powerful cross-platform framework.

For any issues or questions, please open an issue in the [GitHub repository](https://github.com/krishna-bahadur/Dot-Net-MAUI/issues).

---

Happy movie watching!

