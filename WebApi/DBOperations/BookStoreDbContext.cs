using System;
using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
        // default constructer'ını yaratıyoruz.
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        { }
        // database'e entity ekliyoruz 
        public DbSet<Book> Books { get; set; }
    } 
}