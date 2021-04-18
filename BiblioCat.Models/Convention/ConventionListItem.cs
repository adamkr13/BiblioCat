using BiblioCat.Models.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.Convention
{
    public class ConventionListItem
    {
        public int ConventionId { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual List<AuthorListItem> AuthorsAttending { get; set; }
    }
}
