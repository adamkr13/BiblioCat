using BiblioCat.Data;
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

        public IEnumerable<SeriesBookListItem> GetSeriesBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.SeriesBooks.Select(e =>
                    new SeriesBookListItem
                    {
                        SeriesId = e.SeriesId,
                        SeriesName = e.Series.SeriesName,
                        BookId = e.BookId,
                        Title = e.Book.Title
                    });
                return query.ToArray();
            }
        }

        public bool CreateSeriesBook(SeriesBookCreate model)
        {
            var entity = new SeriesBook()
            {
                SeriesId = model.SeriesId,
                BookId = model.BookId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SeriesBooks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSeriesBook(int seriesId, int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.SeriesBooks
                    .Single(e => e.SeriesId == seriesId && e.BookId == bookId);

                if (entity != null)
                {
                    ctx.SeriesBooks.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }

                return false;
            }
        }

        public SeriesBookDetail GetSeriesBookById(int seriesId, int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.SeriesBooks
                    .Single(e => e.SeriesId == seriesId && e.BookId == bookId);

                return new SeriesBookDetail
                {
                    SeriesId = entity.SeriesId,
                    SeriesName = entity.Series.SeriesName,
                    BookId = entity.BookId,
                    Title = entity.Book.Title
                };
            }
        }

        public List<SelectListItem> SeriesOptions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.SeriesPlural.Select(s =>
                    new SelectListItem
                    {
                        Text = s.SeriesName,
                        Value = s.SeriesId.ToString()
                    });

                var seriesList = query.ToList();
                var orderedSeriesList = seriesList.OrderBy(e => e.Text).ToList();
                orderedSeriesList.Insert(0, new SelectListItem { Text = "--Select Series--", Value = "" });

                return orderedSeriesList;
            }
        }

        public List<SelectListItem>  BookOptions()
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
    }
}
