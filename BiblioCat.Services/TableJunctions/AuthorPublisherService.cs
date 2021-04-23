using BiblioCat.Data;
using BiblioCat.Models.Author;
using BiblioCat.Models.Publisher;
using BiblioCat.Models.TableJunctions.AuthorPublisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BiblioCat.Services.TableJunctions
{
    public class AuthorPublisherService
    {
        private readonly Guid _userId;

        public AuthorPublisherService(Guid userId)
        {
            _userId = userId;
        }        

        public bool AddAuthor(AddAuthorsCreate model)
        {
            foreach (int authorId in model.Authors)
            {
                var entity = new AuthorPublisher()
                {
                    AuthorId = authorId,
                    PublisherId = model.PublisherId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.AuthorPublishers.Add(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public bool AddPublisher(AddPublishersCreate model)
        {
            foreach (int publisherId in model.Publishers)
            {
                var entity = new AuthorPublisher()
                {
                    AuthorId = model.AuthorId,
                    PublisherId = publisherId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.AuthorPublishers.Add(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public bool RemoveAuthor(AddAuthorsCreate model)
        {
            foreach (int authorId in model.Authors)
            {
                var entity = new AuthorPublisher()
                {
                    AuthorId = authorId,
                    PublisherId = model.PublisherId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.AuthorPublishers.Attach(entity);
                    ctx.AuthorPublishers.Remove(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public bool RemovePublisher(AddPublishersCreate model)
        {
            foreach (int publisherId in model.Publishers)
            {
                var entity = new AuthorPublisher()
                {
                    AuthorId = model.AuthorId,
                    PublisherId = publisherId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.AuthorPublishers.Attach(entity);
                    ctx.AuthorPublishers.Remove(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public List<SelectListItem> AuthorOptions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Authors.Select(a =>
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
                    Text = "--Select Publisher--", Value = ""
                });

                return orderedPublisherList;
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
