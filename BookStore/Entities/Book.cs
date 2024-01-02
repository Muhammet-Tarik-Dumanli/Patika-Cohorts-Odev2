using System;
using System.ComponentModel.DataAnnotations.Schema;
using BookStore.Entities;

namespace BookStore
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Identity olduğunu ifade eder. Auto Increment
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
