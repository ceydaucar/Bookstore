using AutoMapper;
using WebApi.Entities;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using static WebApi.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static WebApi.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            
            CreateMap<Book,BookDetailViewModel>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=> src.Genre.Name));
            CreateMap<Book,BooksViewModel>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=> src.Genre.Name));
            
            CreateMap<CreateGenreModel, Genre>();
            
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            
            CreateMap<CreateAuthorModel, Author>();
            
            CreateMap<Author, AuthorsViewModel>();
            CreateMap<Author, AuthorDetailViewModel>();

        }
    }
}