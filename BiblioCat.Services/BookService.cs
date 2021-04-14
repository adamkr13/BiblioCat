using BiblioCat.Data;
using BiblioCat.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Services
{
    public class BookService
    {
        private readonly Guid _userId;

        public BookService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<BookListItem> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Books
                        .Select(b =>
                        new BookListItem
                        {
                            BookId = b.BookId,
                            Title = b.Title,
                            GenreOfBook = b.GenreOfBook,
                            PublicationDate = b.PublicationDate
                        });
                return query.ToArray();
            }
        }

        public bool CreateBook(BookCreate model)
        {
            var entity =
                new Book()
                {
                    Title = model.Title,
                    PublicationDate = model.PublicationDate,
                    ISBN = model.ISBN,
                    GenreOfBook = model.GenreOfBook,
                    FormatOfBook = model.FormatOfBook,
                    LoanedTo = model.LoanedTo,
                    Narrator = model.Narrator,
                    Translator = model.Translator,
                    Illustrator = model.Illustrator,
                    IsFirstEdition = model.IsFirstEdition,
                    IHaveRead = model.IHaveRead,
                    IOwn = model.IOwn
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public BookDetail GetBookById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookId == id);

                return
                    new BookDetail
                    {
                        BookId = entity.BookId,
                        Title = entity.Title,
                        PublicationDate = entity.PublicationDate,
                        ISBN = entity.ISBN,
                        GenreOfBook = entity.GenreOfBook,
                        FormatOfBook = entity.FormatOfBook,
                        LoanedTo = entity.LoanedTo,
                        Narrator = entity.Narrator,
                        Translator = entity.Translator,
                        Illustrator = entity.Illustrator,
                        IsFirstEdition = entity.IsFirstEdition,
                        IHaveRead = entity.IHaveRead,
                        IOwn = entity.IOwn
                    };
            }
        }
        public bool UpdateBook(BookEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookId == model.BookId);

                entity.BookId = model.BookId;
                entity.Title = model.Title;
                entity.PublicationDate = model.PublicationDate;
                entity.ISBN = model.ISBN;
                entity.GenreOfBook = model.GenreOfBook;
                entity.FormatOfBook = model.FormatOfBook;
                entity.LoanedTo = model.LoanedTo;
                entity.Narrator = model.Narrator;
                entity.Translator = model.Translator;
                entity.Illustrator = model.Illustrator;
                entity.IsFirstEdition = model.IsFirstEdition;
                entity.IHaveRead = model.IHaveRead;
                entity.IOwn = model.IOwn;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBook(int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookId == bookId);

                ctx.Books.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
