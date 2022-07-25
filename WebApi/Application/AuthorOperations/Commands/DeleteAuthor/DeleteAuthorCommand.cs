using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }

        private readonly IBookStoreDbContext _context;

        public DeleteAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.Include(a=>a.Books).SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
                throw new InvalidOperationException("Silinecek Yazar Bulunamadı!");
            
            if (author.Books.Any())
                throw new InvalidOperationException("Yazarın Kitapları Mevcut, Lütfen Önce Kitapları Siliniz.");
            
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}