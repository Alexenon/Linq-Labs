using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Movie
    {
        string title;
        int year;
        double rating;
        int budget;

        public Movie(string title, int year, double rating, int budget)
        {
            this.title = title;
            this.budget = budget;
            this.year = year;
            this.rating = rating;
        }

        public static void printMovie(Movie movie)
        {
            String result = $"Movie: {movie.title}, {movie.year}, {movie.rating}, {movie.budget}";
            Console.WriteLine(result);
        }

        public static void printMovies(List<Movie> movies)
        {
            foreach (Movie movie in movies)
            {
                printMovie(movie);
            }
        }

        public static List<Movie> getMovieFrom(List<Movie> movies, int year)
        {
            return movies.Where(m => m.year == year).ToList();
        }

        public static List<Movie> getMovieBeginsWith(List<Movie> movies, string str)
        {
            return movies.Where(m => m.title.StartsWith(str)).ToList();
        }

        public static List<Movie> getMovieContains(List<Movie> movies, string str)
        {
            return movies.Where(m => m.title.Contains(str)).ToList();
        }

        public static Movie getFirstMovie(List<Movie> movies)
        {
            return movies.First();
        }

        public static Movie getLastMovie(List<Movie> movies)
        {
            return movies.Last();
        }

        public static List<Movie> getMovieWithBudgetHigher(List<Movie> movies, double budget)
        {
            return movies.Where(m => m.budget >= budget).ToList();
        }

        public static List<Movie> getMovieWithRatingHigher(List<Movie> movies, double rating)
        {
            return movies.Where(m => m.rating >= rating).ToList();
        }

        public static List<Movie> getMovieWhileTitleIsLonger(List<Movie> movies, int titleLength)
        {
            return movies.TakeWhile(m => m.title.Length <= titleLength).ToList();
        }

        public static void getSortedFilmsByName(List<Movie>  movies)
        {
            var orderedMovies = from movie in movies
                                orderby movie.title
                                select movie;

            foreach(Movie movie in orderedMovies)
            {
                printMovie(movie);
            }

        }
    }


}
