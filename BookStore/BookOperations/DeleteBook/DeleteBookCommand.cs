using System;
using System.Linq;
using BookStore.DbOperations;

namespace BookStore.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbcontext;
        public int BookId { get; set; }

        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void Handle()
        {
            var book = _dbcontext.Books.SingleOrDefault(x => x.Id == BookId);

            if(book == null)
                throw new InvalidOperationException("Silinecek kitap bulunamadı!");

            _dbcontext.Books.Remove(book);
            _dbcontext.SaveChanges();
        }
    }
}