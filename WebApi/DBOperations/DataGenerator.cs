using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;
using WebApi.Application.BookOperations;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any()) // hiç verisi varsa
                    return;
                
                context.Authors.AddRange(
                    new Author{
                        Name="Eric",
                        Surname="Ries",
                        DateOfBirth = new DateTime(1978,10,22)
                    },
                    new Author{
                        Name="Charlotte",
                        Surname="Gilman",
                        DateOfBirth = new DateTime(1870,03,07)
                    },
                    new Author{
                        Name="Frank",
                        Surname="Herbet",
                        DateOfBirth = new DateTime(1920,11,08)
                    }
                );

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },

                    new Genre
                    {
                        Name = "Science Fiction"
                    },

                    new Genre
                    {
                        Name = "Romance"
                    }
                );

                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001,06,12)
                    },

                    new Book
                    {
                        //Id = 2,
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010,05,23)
                    },
                    
                    new Book
                    {
                        //Id = 3,
                        Title = "Dune",
                        GenreId = 2,
                        PageCount = 540,
                        PublishDate = new DateTime(2001,12,21)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}