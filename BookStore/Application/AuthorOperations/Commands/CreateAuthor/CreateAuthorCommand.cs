using System;
using System.Linq;
using AutoMapper;
using BookStore.DbOperations;
using BookStore.Entities;

namespace BookStore.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        public CreateAuthorModel Model { get; set; }
        private readonly IMapper _mapper;
        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var addedAuthor = _context.Authors.SingleOrDefault(x => x.FirstName == Model.FirstName && x.LastName == Model.LastName);
            if (addedAuthor != null)
                throw new InvalidOperationException("Yazar zaten mevcut");
            addedAuthor = _mapper.Map<Author>(Model);
            _context.Authors.Add(addedAuthor);
            _context.SaveChanges();
        }
    }

    public class CreateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}