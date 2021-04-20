using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Data
{
    public class Convention
    {
        [Key]
        public int ConventionId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }        

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string Hotel { get; set; }

        public string Website { get; set; }

        public virtual List<AuthorConvention> AuthorsAttending { get; set; } = new List<AuthorConvention>();

    }
}
