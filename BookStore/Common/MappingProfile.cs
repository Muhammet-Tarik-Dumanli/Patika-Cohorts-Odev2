using AutoMapper;
using BookStore.Application.GenreOpereations.Queries.GetGenreDetail;
using BookStore.Application.GenreOpereations.Queries.GetGenres;
using BookStore.BookOperations.GetBookDetail;
using BookStore.BookOperations.GetBooks;
using BookStore.Entities;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;

namespace BookStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
        }
    }
}