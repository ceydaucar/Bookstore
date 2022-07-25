using System;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class BookStoreDbContext : DbContext, IBookStoreDbContext
    {
        // default constructer'ını yaratıyoruz.
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        { }
        // database'e entity ekliyoruz 
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; } // Resource'lar çoğul oluyor
        public DbSet<Author> Authors { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    } 
}