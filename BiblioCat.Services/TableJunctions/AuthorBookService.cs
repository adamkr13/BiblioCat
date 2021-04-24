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

        public bool AddBook(AddBooksCreate model)
        {
            foreach(int bookId in model.Books)
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
            foreach (int bookId in model.Books)
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

                return query.OrderBy(e => e.Title).ToList();
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

                return query.OrderBy(e => e.LastName).ToList();
            }
        }

        public List<SelectListItem> BookOptions(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Books.Where(b => b.BookId == id)
                    .Select(b =>
                    new SelectListItem
                    {
                        Text = b.Title,
                        Value = b.BookId.ToString()
                    });

                return query.ToList();                
            }
        }

        public List<SelectListItem> AuthorOptions(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Authors.Where(a => a.AuthorId == id)
                    .Select(a =>
                    new SelectListItem
                    {
                        Text = a.LastName + ", " + a.FirstName,
                        Value = a.AuthorId.ToString()
                    });

                return query.ToList();
            }
        }
    }
}
