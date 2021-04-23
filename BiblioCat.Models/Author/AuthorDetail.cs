using BiblioCat.Data;
using BiblioCat.Models.Book;
using BiblioCat.Models.Convention;
using BiblioCat.Models.Publisher;
using BiblioCat.Models.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.Author
{
    public class AuthorDetail
    {
        public int AuthorId { get; set; }        

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        
        [DisplayName("Patreon Site")]
        public string Patreon { get; set; }

        [DisplayName("Official Website")]
        public string OfficialWebsite { get; set; }

        [DisplayName("Amazon Page")]
        public string AmazonPage { get; set; }

        [DisplayName("Goodreads Page")]
        public string GoodreadsPage { get; set; }

        [DisplayName("Twitter Handle")]
        public string TwitterHandle { get; set; }

        [DisplayName("Books by Author")]
        public virtual List<BookListItem> BooksByAuthor { get; set; }

        [DisplayName("Series Written")]
        public virtual List<SeriesListItem> SeriesWritten { get; set; }

        [DisplayName("Published By")]
        public virtual List<PublisherListItem> PublishedBy { get; set; }

        [DisplayName("Conventions Attending")]
        public virtual List<ConventionListItem> ConventionsAttending { get; set; }
    }
}
