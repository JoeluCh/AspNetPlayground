using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ASPdotNETExample.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ASPdotNETExample.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            DbContextOptions<ASPdotNETExampleContext> options = serviceProvider.GetRequiredService<DbContextOptions<ASPdotNETExampleContext>>();
            using ASPdotNETExampleContext context = new(options);

            if (context.Movie.Any())
            {
                return; // Seeded already
            }

            List<Movie> movies = new()
            {
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = "R",
                },

                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating = "A",
                },

                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M,
                    Rating = "A",
                },

                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rating = "F",
                }
            };

            context.Movie.AddRange(movies);

            context.SaveChanges();
        }
    }
}
