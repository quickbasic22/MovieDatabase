using Microsoft.EntityFrameworkCore;
using MovieDatabase.Models;

namespace MovieDatabase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new MovieDatabaseContext();
            var movies = db.Movies.OrderBy(a => a.Title)
                .ToList();

            foreach (Movie movie in movies)
            {
                System.Console.WriteLine(movie.Title);
                System.Console.WriteLine(movie.Released);

            }
            Console.ReadKey();
        }
    }
}