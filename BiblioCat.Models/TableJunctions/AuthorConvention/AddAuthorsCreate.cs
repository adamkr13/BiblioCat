using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.TableJunctions.AuthorConvention
{
    public class AddAuthorsCreate
    {
        public int AuthorId { get; set; }

        [Required]
        public int ConventionId { get; set; }

        public string ConventionName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public int[] Authors { get; set; }
    }
}
