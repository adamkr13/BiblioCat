using BiblioCat.Data;
using BiblioCat.Models.Author;
using BiblioCat.Models.Convention;
using BiblioCat.Models.TableJunctions.AuthorConvention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BiblioCat.Services.TableJunctions
{
    public class AuthorConventionService
    {
        private readonly Guid _userId;

        public AuthorConventionService(Guid userId)
        {
            _userId = userId;
        }        

        public bool AddAuthor(AddAuthorsCreate model)
        {
            foreach (int authorId in model.Authors)
            {
                var entity = new AuthorConvention()
                {
                    AuthorId = authorId,
                    ConventionId = model.ConventionId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.AuthorConventions.Add(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public bool AddConvention(AddConventionsCreate model)
        {
            foreach (int conventionId in model.Conventions)
            {
                var entity = new AuthorConvention()
                {
                    AuthorId = model.AuthorId,
                    ConventionId = conventionId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.AuthorConventions.Add(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public bool RemoveAuthor(AddAuthorsCreate model)
        {
            foreach (int authorId in model.Authors)
            {
                var entity = new AuthorConvention()
                {
                    AuthorId = authorId,
                    ConventionId = model.ConventionId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.AuthorConventions.Attach(entity);
                    ctx.AuthorConventions.Remove(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
        }

        public bool RemoveConvention(AddConventionsCreate model)
        {
            foreach (int conventionId in model.Conventions)
            {
                var entity = new AuthorConvention()
                {
                    AuthorId = model.AuthorId,
                    ConventionId = conventionId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.AuthorConventions.Attach(entity);
                    ctx.AuthorConventions.Remove(entity);
                    var changes = ctx.SaveChanges();
                }
            }

            return true;
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

        public List<SelectListItem> ConventionOptions(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Conventions.Where(c => c.ConventionId == id)
                    .Select(c =>
                    new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.ConventionId.ToString()
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

        public List<ConventionListItem> GetConventions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Conventions.Select(e =>
                    new ConventionListItem
                    {
                        ConventionId = e.ConventionId,
                        Name = e.Name
                    });

                return query.OrderBy(e => e.Name).ToList();
            }
        }
    }
}
