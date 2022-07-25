using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;
using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }

        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGenreCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Name == Model.Name);

            if (genre is not null)
                throw new InvalidOperationException("Kitap Türü Zaten Mevcut!");
            
            genre = _mapper.Map<Genre>(Model);
            
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();

        }

        public class CreateGenreModel
        {
            public string Name { get; set; }
        }
    }
}