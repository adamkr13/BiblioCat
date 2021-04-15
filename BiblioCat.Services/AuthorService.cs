using BiblioCat.Data;
using BiblioCat.Models.Author;
using BiblioCat.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Services
{
    public class AuthorService
    {
        private readonly Guid _userId;

        public AuthorService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<AuthorListItem> GetAuthors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Authors
                        .Select(e =>
                        new AuthorListItem
                        {
                            AuthorId = e.AuthorId,
                            LastName = e.LastName,
                            FirstName = e.FirstName,
                            BookIds = e.BooksByAuthor.Select(b => b.Book.BookId).ToList(),
                            BookTitles = e.BooksByAuthor.Select(b => b.Book.Title).ToList()
                        });

                return query.ToArray();
            }
        }

        public bool CreateAuthor(AuthorCreate model)
        {
            var entity =
                new Author()
                {
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                    Email = model.Email,
                    OfficialWebsite = model.OfficialWebsite,
                    AmazonPage = model.AmazonPage,
                    GoodreadsPage = model.GoodreadsPage,
                    TwitterHandle = model.TwitterHandle
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Authors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public AuthorDetail GetAuthorById(int id)
        {
            using (var ctx  = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.AuthorId == id);

                return
                    new AuthorDetail
                    {
                        AuthorId = entity.AuthorId,
                        LastName = entity.LastName,
                        FirstName = entity.FirstName,
                        Email = entity.Email,
                        OfficialWebsite = entity.OfficialWebsite,
                        AmazonPage = entity.AmazonPage,
                        GoodreadsPage = entity.GoodreadsPage,
                        TwitterHandle = entity.TwitterHandle,
                        BooksByAuthor = entity.BooksByAuthor.Select(b => new BookListItem()
                        {
                            BookId = b.BookId,
                            Title = b.Book.Title
                        }).ToList()
                    };
            }
        }

        public bool UpdateAuthor(AuthorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.AuthorId == model.AuthorId);

                entity.LastName = model.LastName;
                entity.FirstName = model.FirstName;
                entity.Email = model.Email;
                entity.OfficialWebsite = model.OfficialWebsite;
                entity.AmazonPage = model.AmazonPage;
                entity.GoodreadsPage = model.GoodreadsPage;
                entity.TwitterHandle = model.TwitterHandle;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAuthor(int authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.AuthorId == authorId);

                ctx.Authors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
