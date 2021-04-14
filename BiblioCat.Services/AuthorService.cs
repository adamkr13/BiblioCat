using BiblioCat.Data;
using BiblioCat.Models.Author;
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
                        .Select(a =>
                        new AuthorListItem
                        {
                            AuthorId = a.AuthorId,
                            LastName = a.LastName,
                            FirstName = a.FirstName
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
                        LastName = entity.LastName,
                        FirstName = entity.FirstName,
                        Email = entity.Email,
                        OfficialWebsite = entity.OfficialWebsite,
                        AmazonPage = entity.AmazonPage,
                        GoodreadsPage = entity.GoodreadsPage,
                        TwitterHandle = entity.TwitterHandle
                    };
            }
        }
    }
}
