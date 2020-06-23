using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
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
                        Guest = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Note = "Romantic Comedy"
                    },

                    new Movie
                    {
                        Guest = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Note = "Comedy"
                    },

                    new Movie
                    {
                        Guest = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Note = "Comedy"
                    },

                    new Movie
                    {
                        Guest = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Note = "Western"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}