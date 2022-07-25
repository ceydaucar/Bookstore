using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            var authorList = _context.Authors.OrderBy(x=>x.Id).ToList();
            List<AuthorsViewModel> returnList = _mapper.Map<List<AuthorsViewModel>>(authorList);

            return returnList;
        }
    }

    public class AuthorsViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }
        
        public string DateOfBirth { get; set; }

        public List<Book> Books { get; set; }
    }
}