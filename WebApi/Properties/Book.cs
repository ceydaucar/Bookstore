using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // id' yi otomatik atamak için kullanılan bir attribute
        public int Id { get; set; }

        public string Title { get; set; }

        public int GenreId { get; set; }

        public int PageCount { get; set; }

        public DateTime PublishDate { get; set; }
    }
}