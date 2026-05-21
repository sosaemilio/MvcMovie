using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "Interstellar",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Sci-Fi",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Sci-Fi",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Star Wars - Revenge of the Sith",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Sci-Fi",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Harry Potter and the Sorcerer's Stone",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Fantasy",
                    Price = 3.99M
                },
                new Movie
                {
                    Title = "Westworld",
                    ReleaseDate = DateTime.Parse("1989-1-11"),
                    Genre = "Sci-Fi",
                    Rating = "R",
                    Price = 7.99M
                }
            );
            context.SaveChanges();
        }
    }
}

