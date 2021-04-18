using BiblioCat.Data;
using BiblioCat.Models.TableJunctions.AuthorConvention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Services.TableJunctions
{
    public class AuthorConventionService
    {
        private readonly Guid _userId;

        public AuthorConventionService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<AuthorConventionListItem> GetAuthorConventions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.AuthorConventions
                    .Select(e =>
                    new AuthorConventionListItem
                    {
                        AuthorId = e.AuthorId,
                        LastName = e.Author.LastName,
                        FirstName = e.Author.FirstName,
                        ConventionId = e.ConventionId,
                        ConventionName = e.Convention.Name
                    });
                return query.ToArray();
            }
        }

        public bool CreateAuthorConvention(AuthorConventionCreate model)
        {
            var entity = new AuthorConvention()
            {
                AuthorId = model.AuthorId,
                ConventionId = model.ConventionId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.AuthorConventions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAuthorConvention(int authorId, int conventionId)
        {
            
        }
    }
}
