using BiblioCat.Data;
using BiblioCat.Models.Author;
using BiblioCat.Models.Publisher;
using BiblioCat.Models.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.Book
{
    public class BookListItem
    {        
        public int BookId { get; set; }

        public string Title { get; set; }

        [DisplayName("Genre")]
        public BookGenre GenreOfBook { get; set; }

        [DisplayName("Publication Date")]
        public DateTime PublicationDate { get; set; }        

        [DisplayName("Author(s) of Book")]
        public virtual List<AuthorListItem> AuthorsOfBook { get; set; }

        [DisplayName("Part of Series")]
        public List<SeriesListItem> SeriesNames { get; set; }

        [DisplayName("Published By")]
        public List<PublisherListItem> PublisherNames { get; set; }
    }
}
