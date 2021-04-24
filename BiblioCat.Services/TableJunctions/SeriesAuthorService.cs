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

        public List<SelectListItem> AuthorOptions(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Authors.Where(a => a.AuthorId == id)
                    .Select(a =>
                    new SelectListItem
                    {
                        Text = a.LastName + ", " + a.FirstName,
                        Value = a.AuthorId.ToString()
                    });

                return query.ToList();
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

                return query.OrderBy(e => e.LastName).ToList();
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
