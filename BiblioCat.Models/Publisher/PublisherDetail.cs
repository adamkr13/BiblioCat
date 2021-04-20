using BiblioCat.Models.Author;
using BiblioCat.Models.Book;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.Publisher
{
    public class PublisherDetail
    {
        public int PublisherId { get; set; }

        [DisplayName("Publisher")]
        public string PublisherName { get; set; }

        public string Address { get; set; }

        [DisplayName("Official Website")]
        public string PublisherWebsite { get; set; }

        [DisplayName("Books Published")]
        public virtual List<BookListItem> BookTitles { get; set; }

        [DisplayName("Authors with Publisher")]
        public virtual List<AuthorListItem> AuthorsWithPublisher { get; set; }
    }
}
