using BiblioCat.Data;
using BiblioCat.Models.Author;
using BiblioCat.Models.Book;
using BiblioCat.Models.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Services
{
    public class SeriesService
    {
        private readonly Guid _userId;

        public SeriesService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<SeriesListItem> GetSeries()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .SeriesPlural
                        .Select(e =>
                        new SeriesListItem
                        {
                            SeriesId = e.SeriesId,
                            SeriesName = e.SeriesName,
                            AuthorsInSeries = e.AuthorsInSeries.Select(a => new AuthorListItem()
                            {
                                AuthorId = a.AuthorId,
                                LastName = a.Author.LastName,
                                FirstName = a.Author.FirstName
                            }).ToList(),
                            BooksInSeries = e.SeriesOfBook.Select(b => new BookListItem()
                            {
                                BookId = b.BookId,
                                Title = b.Book.Title
                            }).ToList()
                        });
                return query.ToArray();
            }
        }

        public bool CreateSeries (SeriesCreate model)
        {
            var entity =
                new Series()
                {
                    SeriesName = model.SeriesName,
                    SeriesDescription = model.SeriesDescription
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SeriesPlural.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public SeriesDetail GetSeriesById(int id)
        {
            using (var ctx = new ApplicationDbContext)
            {
                var entity =
                    ctx
                        .SeriesPlural
                        .Single(e => e.SeriesId == id);

                return
                    new SeriesDetail
                    {
                        SeriesId = entity.SeriesId,
                        SeriesName = entity.SeriesName,
                        SeriesDescription = entity.SeriesDescription,
                        AuthorsInSeries = entity.AuthorsInSeries.Select(a => new AuthorListItem()
                        {
                            AuthorId = a.AuthorId,
                            LastName = a.Author.LastName,
                            FirstName = a.Author.FirstName
                        }).ToList(),
                        BooksInSeries = entity.BooksInSeries.Select(b => new BookListItem()
                        {
                            BookId = b.BookId,
                            Title = b.Book.Title
                        }).ToList()
                    };
            }
        }

        public bool UpdateSeries(SeriesEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SeriesPlural
                        .Single(e => e.SeriesId == model.SeriesId);

                entity.SeriesId = model.SeriesId;
                entity.SeriesName = model.SeriesName;
                entity.SeriesDescription = model.SeriesDescription;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSeries(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SeriesPlural
                        .Single(e => e.SeriesId == id);

                ctx.SeriesPlural.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
