using BiblioCat.Data;
using BiblioCat.Models.Book;
using BiblioCat.Models.Series;
using BiblioCat.Models.TableJunctions.SeriesBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BiblioCat.Services.TableJunctions
{
    public class SeriesBookService
    {
        private readonly Guid _userId;

        public SeriesBookService(Guid userId)
        {
            _userId = userId;
        }        

        public bool AddBook(AddBooksCreate model)
        {
            foreach (int bookId in model.Books)
            {
                var entity = new SeriesBook()
                {
                    BookId = bookId,
                    SeriesId = model.SeriesId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.SeriesBooks.Add(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public bool AddSeries(AddSeriesCreate model)
        {
            foreach (int seriesId in model.Series)
            {
                var entity = new SeriesBook()
                {
                    BookId = model.BookId,
                    SeriesId = seriesId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.SeriesBooks.Add(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public bool RemoveBook(AddBooksCreate model)
        {
            foreach (int bookId in model.Books)
            {
                var entity = new SeriesBook()
                {
                    BookId = bookId,
                    SeriesId = model.SeriesId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.SeriesBooks.Attach(entity);
                    ctx.SeriesBooks.Remove(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public bool RemoveSeries(AddSeriesCreate model)
        {
            foreach (int seriesId in model.Series)
            {
                var entity = new SeriesBook()
                {
                    BookId = model.BookId,
                    SeriesId = seriesId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.SeriesBooks.Attach(entity);
                    ctx.SeriesBooks.Remove(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public List<SelectListItem> SeriesOptions(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.SeriesPlural.Where(s => s.SeriesId == id)
                    .Select(s =>
                    new SelectListItem
                    {
                        Text = s.SeriesName,
                        Value = s.SeriesId.ToString()
                    });

                return query.ToList();
            }
        }

        public List<SelectListItem>  BookOptions(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Books.Where(b => b.BookId == id)
                    .Select(b =>
                    new SelectListItem
                    {
                        Text = b.Title,
                        Value = b.BookId.ToString()
                    });

                return query.ToList();
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

                return query.OrderBy(e => e.Title).ToList();
            }
        }

        public List<SeriesListItem> GetSeries()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.SeriesPlural.Select(e =>
                    new SeriesListItem
                    {
                        SeriesId = e.SeriesId,
                        SeriesName = e.SeriesName
                    });

                return query.OrderBy(e => e.SeriesName).ToList();
            }
        }
    }
}
