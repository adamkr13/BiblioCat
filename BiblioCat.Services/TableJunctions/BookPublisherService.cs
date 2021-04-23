﻿using BiblioCat.Data;
using BiblioCat.Models.Book;
using BiblioCat.Models.Publisher;
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

        public bool AddBook(AddBooksCreate model)
        {
            foreach (int bookId in model.Books)
            {
                var entity = new BookPublisher()
                {
                    BookId = bookId,
                    PublisherId = model.PublisherId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.BookPublishers.Add(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public bool AddPublisher(AddPublishersCreate model)
        {
            foreach (int publisherId in model.Publishers)
            {
                var entity = new BookPublisher()
                {
                    BookId = model.BookId,
                    PublisherId = publisherId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.BookPublishers.Add(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public bool RemoveBook(AddBooksCreate model)
        {
            foreach (int bookId in model.Books)
            {
                var entity = new BookPublisher()
                {
                    BookId = bookId,
                    PublisherId = model.PublisherId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.BookPublishers.Attach(entity);
                    ctx.BookPublishers.Remove(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public bool RemovePublisher(AddPublishersCreate model)
        {
            foreach (int publisherId in model.Publishers)
            {
                var entity = new BookPublisher()
                {
                    BookId = model.BookId,
                    PublisherId = publisherId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.BookPublishers.Attach(entity);
                    ctx.BookPublishers.Remove(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
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

        public List<BookListItem> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Books.Select(e =>
                    new BookListItem
                    {
                        BookId = e.BookId,
                        Title = e.Title,                        
                    });

                return query.ToList();
            }
        }

        public List<PublisherListItem> GetPublishers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Publishers.Select(e =>
                    new PublisherListItem
                    {
                        PublisherId = e.PublisherId,
                        PublisherName = e.PublisherName
                    });

                return query.ToList();
            }
        }
    }
}
