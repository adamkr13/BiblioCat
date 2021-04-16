using BiblioCat.Data;
using BiblioCat.Models.Author;
using BiblioCat.Models.Book;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.Series
{
    public class SeriesDetail
    {
        public int SeriesId { get; set; }

        [DisplayName("Name of Series")]
        public string SeriesName { get; set; }

        [DisplayName("Series Description")]
        public string SeriesDescription { get; set; }

        [DisplayName("Authors in the Series")]
        public virtual List<AuthorListItem> AuthorsInSeries { get; set; }

        [DisplayName("Books in Series")]
        public virtual List<BookListItem> BooksInSeries { get; set; }
    }
}
