using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        
        private readonly IBookStoreDbContext _context;

        private readonly IMapper _mapper;

        public GetAuthorDetailQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.Where(x => x.Id == AuthorId).SingleOrDefault();
            
            if (author is null)
                throw new InvalidOperationException("Yazar Bulunamadı!");

            AuthorDetailViewModel avm = _mapper.Map<AuthorDetailViewModel>(author);

            return avm;
        }
    }

    public class AuthorDetailViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Surname { get; set; }
        
        public string DateOfBirth { get; set; }

        public List<Book> Books { get; set; }
    }
}