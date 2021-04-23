using BiblioCat.Data;
using BiblioCat.Models.Author;
using BiblioCat.Models.Series;
using BiblioCat.Models.TableJunctions.SeriesAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BiblioCat.Services.TableJunctions
{
    public class SeriesAuthorService
    {
        private readonly Guid _userId;

        public SeriesAuthorService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<SeriesAuthorListItem> GetSeriesAuthors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .SeriesAuthors
                        .Select(e =>
                        new SeriesAuthorListItem
                        {
                            SeriesId = e.SeriesId,
                            SeriesName = e.Series.SeriesName,
                            AuthorId = e.AuthorId,
                            LastName = e.Author.LastName,
                            FirstName = e.Author.FirstName
                        });
                return query.ToArray();
            }
        }

        public bool AddAuthor(AddAuthorsCreate model)
        {
            foreach (int authorId in model.Authors)
            {
                var entity = new SeriesAuthor()
                {
                    AuthorId = authorId,
                    SeriesId = model.SeriesId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.SeriesAuthors.Add(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public bool AddSeries(AddSeriesCreate model)
        {
            foreach (int seriesId in model.Series)
            {
                var entity = new SeriesAuthor()
                {
                    AuthorId = model.AuthorId,
                    SeriesId = seriesId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.SeriesAuthors.Add(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public bool RemoveAuthor(AddAuthorsCreate model)
        {
            foreach (int authorId in model.Authors)
            {
                var entity = new SeriesAuthor()
                {
                    AuthorId = authorId,
                    SeriesId = model.SeriesId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.SeriesAuthors.Attach(entity);
                    ctx.SeriesAuthors.Remove(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public bool RemoveSeries(AddSeriesCreate model)
        {
            foreach (int seriesId in model.Series)
            {
                var entity = new SeriesAuthor()
                {
                    AuthorId = model.AuthorId,
                    SeriesId = seriesId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.SeriesAuthors.Attach(entity);
                    ctx.SeriesAuthors.Remove(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        //public bool CreateSeriesAuthor(SeriesAuthorCreate model)
        //{
        //    var entity = new SeriesAuthor()
        //    {
        //        SeriesId = model.SeriesId,
        //        AuthorId = model.AuthorId
        //    };

        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        ctx.SeriesAuthors.Add(entity);
        //        return ctx.SaveChanges() == 1;
        //    }
        //}

        //public bool DeleteSeriesAuthor(int seriesId, int authorId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .SeriesAuthors
        //                .Single(e => e.SeriesId == seriesId && e.AuthorId == authorId);

        //        if (entity != null)
        //        {
        //            ctx.SeriesAuthors.Remove(entity);
        //            return ctx.SaveChanges() == 1;
        //        }

        //        return false;
        //    }
        //}

        //public SeriesAuthorDetail GetSeriesAuthorById(int seriesId, int authorId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx.SeriesAuthors
        //            .Single(e => e.SeriesId == seriesId && e.AuthorId == authorId);

        //        return new SeriesAuthorDetail
        //        {
        //            SeriesId = entity.SeriesId,
        //            SeriesName = entity.Series.SeriesName,
        //            AuthorId = entity.AuthorId,
        //            LastName = entity.Author.LastName,
        //            FirstName = entity.Author.FirstName
        //        };
        //    }
        //}

        public List<SelectListItem> SeriesOptions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.SeriesPlural
                    .Select(s =>
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

        public List<SelectListItem> AuthorOptions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Authors.Select(a =>
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

                return query.ToList();
            }
        }
    }
}
