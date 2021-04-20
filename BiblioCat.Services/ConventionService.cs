using BiblioCat.Data;
using BiblioCat.Models.Author;
using BiblioCat.Models.Convention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Services
{
    public class ConventionService
    {
        private readonly Guid _userId;

        public ConventionService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<ConventionListItem> GetConventions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Conventions
                    .Select(e =>
                    new ConventionListItem
                    {
                        ConventionId = e.ConventionId,
                        Name = e.Name,
                        City = e.City,
                        State = e.State,
                        StartDate = e.StartDate,
                        EndDate = e.EndDate,
                        AuthorsAttending = e.AuthorsAttending.Select(a => new AuthorListItem()
                        {
                            AuthorId = a.AuthorId,
                            LastName = a.Author.LastName,
                            FirstName = a.Author.FirstName
                        }).ToList(),
                    });
                return query.ToArray();
            }
        }

        public bool CreateConvention(ConventionCreate model)
        {
            var entity =
                new Convention()
                {
                    Name = model.Name,
                    City = model.City,
                    State = model.State,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Hotel = model.Hotel,
                    Website = model.Website
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Conventions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ConventionDetail GetConventionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Conventions
                    .Single(e => e.ConventionId == id);

                return new ConventionDetail
                {
                    ConventionId = entity.ConventionId,
                    Name = entity.Name,
                    City = entity.City,
                    State = entity.State,
                    StartDate = entity.StartDate,
                    EndDate = entity.EndDate,
                    Hotel = entity.Hotel,
                    Website = entity.Website,
                    AuthorsAttending = entity.AuthorsAttending.Select(a => new AuthorListItem()
                    {
                        AuthorId = a.AuthorId,
                        LastName = a.Author.LastName,
                        FirstName = a.Author.FirstName
                    }).ToList()
                };
            }
        }

        public bool UpdateConvention(ConventionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Conventions
                    .Single(e => e.ConventionId == model.ConventionId);

                entity.ConventionId = model.ConventionId;
                entity.Name = model.Name;
                entity.City = model.City;
                entity.State = model.State;
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.Hotel = model.Hotel;
                entity.Website = model.Website;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteConvention(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Conventions
                    .Single(e => e.ConventionId == id);

                ctx.Conventions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
