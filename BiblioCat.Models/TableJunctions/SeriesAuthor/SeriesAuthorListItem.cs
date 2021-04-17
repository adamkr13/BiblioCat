using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.TableJunctions.SeriesAuthor
{
    public class SeriesAuthorListItem
    {
        public int SeriesId { get; set; }

        [DisplayName("Name of Series")]
        public string SeriesName { get; set; }

        public int AuthorId { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }
    }
}
