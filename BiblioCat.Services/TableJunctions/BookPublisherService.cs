using BiblioCat.Data;
using BiblioCat.Models.TableJunctions.BookPublisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BiblioCat.Services.TableJunctions
{
    public class BookPublisherService
    {
        private Guid _userId;

        public BookPublisherService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<BookPublisherListItem> GetBookPublishers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.BookPublishers
                    .Select(e =>
                    new BookPublisherListItem
                    {
                        BookId = e.BookId,
                        Title = e.Book.Title,
                        PublisherId = e.PublisherId,
                        PublisherName = e.Publisher.PublisherName
                    });
                return query.ToArray();
            }
        }

        public bool CreateBookPublisher(BookPublisherCreate model)
        {
            var entity = new BookPublisher()
            {
                BookId = model.BookId,
                PublisherId = model.PublisherId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.BookPublishers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBookPublisher(int bookId, int publisherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.BookPublishers
                    .Single(e => e.BookId == bookId && e.PublisherId == publisherId);

                if (entity != null)
                {
                    ctx.BookPublishers.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }

                return false;
            }
        }

        public BookPublisherDetail GetBookPublisherById(int bookId, int publisherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.BookPublishers
                    .Single(e => e.BookId == bookId && e.PublisherId == publisherId);

                return new BookPublisherDetail
                {
                    BookId = entity.BookId,
                    Title = entity.Book.Title,
                    PublisherId = entity.PublisherId,
                    PublisherName = entity.Publisher.PublisherName
                };
            }
        }

        public List<SelectListItem> BookOptions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Books.Select(s =>
                    new SelectListItem
                    {
                        Text = s.Title,
                        Value = s.BookId.ToString()
                    });

                var bookList = query.ToList();
                var orderedBookList = bookList.OrderBy(e => e.Text).ToList();
                orderedBookList.Insert(0, new SelectListItem { Text = "--Select Book--", Value = "" });

                return orderedBookList;
            }
        }

        public List<SelectListItem> PublisherOptions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Publishers.Select(p =>
                    new SelectListItem
                    {
                        Text = p.PublisherName,
                        Value = p.PublisherId.ToString()
                    });

                var publisherList = query.ToList();
                var orderedPublisherList = publisherList.OrderBy(e => e.Text).ToList();
                orderedPublisherList.Insert(0, new SelectListItem
                {
                    Text = "--Select Publisher--",
                    Value = ""
                });

                return orderedPublisherList;
            }
        }
    }
}
