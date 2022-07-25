using AutoMapper;
using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public UpdateAuthorModel Model { get; set; }

        public int AuthorId { get; set; }

        private readonly IBookStoreDbContext _context;

        public UpdateAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
                throw new InvalidOperationException("Güncellenecek Yazar Bulunamadı!");
                
            if (_context.Authors.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Surname == Model.Surname.ToLower() && x.Id != AuthorId))
                throw new InvalidOperationException("Bu İsimde Bir Yazar Zaten Mevcut!");
                
            author.Name = Model.Name.Trim() != default ? Model.Name : author.Name;
            author.Surname = Model.Surname != default ? Model.Surname : author.Surname;
            author.DateOfBirth = Model.DateOfBirth != default ? Model.DateOfBirth : author.DateOfBirth;
            
            _context.SaveChanges();
        }
    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}