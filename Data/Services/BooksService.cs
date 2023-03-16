using myBooks.Data.Models;
using myBooks.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBooks.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }
        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Rate = book.Rate,
                PublisherID = book.PublisherId
            };
            _context.Books.Add(_book);
            _context.SaveChangesAsync();

            foreach(var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Books_Authors.Add(_book_author);
                _context.SaveChangesAsync();
            }
        }
        public List<Book> GetAllBooks() => _context.Books.ToList();
        public BookWithAuthorsVM GetBookById(int bookId)
        {
            var _bookWithAuthors = _context.Books.Where(n => n.Id == bookId).Select(book => new BookWithAuthorsVM()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Rate = book.Rate,
                PublisherName = book.Publisher.Name,
                Authornames = book.Book_Authors.Select(n => n.Author.Fullname).ToList()
            }).FirstOrDefault();
            return _bookWithAuthors;
           
        }

        public Book UpdateBookById(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _book.Id = book.Id;
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.Rate = book.Rate;

                _context.SaveChangesAsync();
            }

            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if(_book!=null)
            {
                _context.Books.Remove(_book);
                _context.SaveChangesAsync();
            }
        }
    }
}
