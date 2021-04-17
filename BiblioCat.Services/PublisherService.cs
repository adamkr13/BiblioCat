using BiblioCat.Data;
using BiblioCat.Models.Author;
using BiblioCat.Models.Book;
using BiblioCat.Models.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Services
{
    public class PublisherService
    {
        private readonly Guid _userId;

        public PublisherService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<PublisherListItem> GetPublishers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Publishers.Select(e =>
                    new PublisherListItem
                    {
                        PublisherId = e.PublisherId,
                        PublisherName = e.PublisherName,
                        Address = e.Address,
                        PublisherWebsite = e.PublisherWebsite,
                        AuthorsWithPublisher = e.AuthorsWithPublisher.Select(a => new AuthorListItem()
                        {
                            AuthorId = a.AuthorId,
                            LastName = a.Author.LastName,
                            FirstName = a.Author.FirstName
                        }).ToList(),
                        BookTitles = e.BooksPublished.Select(b => new BookListItem()
                        {
                            BookId = b.BookId,
                            Title = b.Book.Title
                        }).ToList()
                    });
                return query.ToArray();
            }
        }

        public bool CreatePublisher(PublisherCreate model)
        {
            var entity =
                new Publisher()
                {
                    PublisherName = model.PublisherName,
                    Address = model.Address,
                    PublisherWebsite = model.PublisherWebsite
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Publishers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public PublisherDetail GetPublisherById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Publishers
                    .Single(e => e.PublisherId == id);

                return new PublisherDetail
                {
                    PublisherId = entity.PublisherId,
                    PublisherName = entity.PublisherName,
                    Address = entity.Address,
                    PublisherWebsite = entity.PublisherWebsite,
                    AuthorsWithPublisher = entity.AuthorsWithPublisher
                        .Select(a => new AuthorListItem()
                        {
                            AuthorId = a.AuthorId,
                            LastName = a.Author.LastName,
                            FirstName = a.Author.FirstName
                        }).ToList(),
                    BookTitles = entity.BooksPublished
                        .Select(b => new BookListItem()
                        {
                            BookId = b.BookId,
                            Title = b.Book.Title
                        }).ToList()
                };
            }
        }

        public bool UpdatePublisher(PublisherEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Publishers
                    .Single(e => e.PublisherId == model.PublisherId);

                entity.PublisherId = model.PublisherId;
                entity.PublisherName = model.PublisherName;
                entity.Address = model.Address;
                entity.PublisherWebsite = model.PublisherWebsite;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePublisher(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Publishers
                    .Single(e => e.PublisherId == id);

                ctx.Publishers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
