using BiblioCat.Models.Book;
using BiblioCat.Models.Convention;
using BiblioCat.Models.Publisher;
using BiblioCat.Models.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.Author
{
    public class AuthorListItem
    {
        public int AuthorId { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Book Titles")]
        public List<BookListItem> BookTitles { get; set; }

        [DisplayName("Series Written")]
        public List<SeriesListItem> SeriesNames { get; set; }

        [DisplayName("Published By")]
        public List<PublisherListItem> PublisherNames { get; set; }

        [DisplayName("Conventions Attending")]
        public List<ConventionListItem> ConventionsAttending { get; set; }
    }
}
