using BiblioCat.Data;
using BiblioCat.Models.Author;
using BiblioCat.Models.Book;
using BiblioCat.Models.TableJunctions.AuthorBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BiblioCat.Services.TableJunctions
{
    public class AuthorBookService
    {
        private readonly Guid _userId;

        public AuthorBookService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<AuthorBookListItem> GetAuthorBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .AuthorBooks
                    .Select(e =>
                    new AuthorBookListItem
                    {
                        AuthorId = e.AuthorId,
                        FirstName = e.Author.FirstName,
                        LastName = e.Author.LastName,
                        BookId = e.BookId,
                        Title = e.Book.Title
                    });

                return query.ToArray();
            }
        }

        public bool CreateAuthorBook(AuthorBookCreate model)
        {
            var entity = new AuthorBook()
            {
                AuthorId = model.AuthorId,
                BookId = model.BookId                
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.AuthorBooks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool AddBook(AddBooksCreate model)
        {
            foreach(int bookId in model.Titles)
            {
                var entity = new AuthorBook()
                {
                    AuthorId = model.AuthorId,
                    BookId = bookId
                };

                using (var ctx = new ApplicationDbContext())
                {                    
                    ctx.AuthorBooks.Add(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;            
        }

        public bool AddAuthor(AddAuthorsCreate model)
        {
            foreach (int authorId in model.Authors)
            {
                var entity = new AuthorBook()
                {
                    AuthorId = authorId,
                    BookId = model.BookId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.AuthorBooks.Add(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public bool RemoveBook(AddBooksCreate model)
        {
            foreach (int bookId in model.Titles)
            {
                var entity = new AuthorBook()
                {
                    AuthorId = model.AuthorId,
                    BookId = bookId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.AuthorBooks.Attach(entity);
                    ctx.AuthorBooks.Remove(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public bool RemoveAuthor(AddAuthorsCreate model)
        {
            foreach (int authorId in model.Authors)
            {
                var entity = new AuthorBook()
                {
                    AuthorId = authorId,
                    BookId = model.BookId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.AuthorBooks.Attach(entity);
                    ctx.AuthorBooks.Remove(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }        

        public bool DeleteAuthorBook(int authorId, int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AuthorBooks
                        .Single(e => e.AuthorId == authorId && e.BookId == bookId);

                if (entity != null)
                {
                    ctx.AuthorBooks.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }

                return false;
            }
        }

        public AuthorBookDetail GetAuthorBookById(int authorId, int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AuthorBooks
                        .Single(e => e.AuthorId == authorId && e.BookId == bookId);

                return new AuthorBookDetail
                {
                    AuthorId = entity.AuthorId,
                    FirstName = entity.Author.FirstName,
                    LastName = entity.Author.LastName,
                    BookId = entity.BookId,
                    Title = entity.Book.Title
                };
            }
        }

        public List<BookListItem> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Books.Select(e =>
                    new BookListItem
                    {
                        BookId = e.BookId,
                        Title = e.Title
                    });

                return query.ToList();
            }
        }

        public List<AuthorListItem> GetAuthors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Authors.Select(e =>
                    new AuthorListItem
                    {
                        AuthorId = e.AuthorId,
                        FirstName = e.FirstName,
                        LastName = e.LastName
                    });

                return query.ToList();
            }
        }

        public List<SelectListItem> BookOptions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Books.Select(b =>
                    new SelectListItem
                    {
                        Text = b.Title,
                        Value = b.BookId.ToString()
                    });

                var bookList = query.ToList();
                var orderedBookList = bookList.OrderBy(e => e.Text).ToList();
                orderedBookList.Insert(0, new SelectListItem { Text = "--Select Book--", Value = "" });

                return orderedBookList;
            }
        }

        public List<SelectListItem> AuthorOptions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Authors.Select(a =>
                    new SelectListItem
                    {
                        Text = a.LastName + ", " + a.FirstName,
                        Value = a.AuthorId.ToString()
                    });

                var authorList = query.ToList();
                var orderedAuthorList = authorList.OrderBy(e => e.Text).ToList();
                orderedAuthorList.Insert(0, new SelectListItem { Text = "--Select Author--", Value = "" });

                return orderedAuthorList;
            }
        }
    }
}
