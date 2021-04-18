using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.TableJunctions.AuthorConvention
{
    public class AuthorConventionDetail
    {
        public int AuthorId { get; set; }

        public int ConventionId { get; set; }

        public string ConventionName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
