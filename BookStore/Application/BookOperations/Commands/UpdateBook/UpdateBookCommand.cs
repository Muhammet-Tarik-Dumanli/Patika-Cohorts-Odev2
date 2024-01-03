using System;
using System.Linq;
using BookStore.DbOperations;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbcontext;
        public int BookId { get; set; }
        public UpdateBookModel Model { get; set; }

        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void Handle()
        {
            var book = _dbcontext.Books.SingleOrDefault(x => x.Id == BookId);

            if(book == null)
                throw new InvalidOperationException("Güncellenecek kitap bulunamadı!");

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.Title = Model.Title != default ? Model.Title : book.Title;

            _dbcontext.SaveChanges();
        }
    }

    public class UpdateBookModel
       {
        public string Title { get; set; }
        public int GenreId { get; set; }
       }
}