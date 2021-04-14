using BiblioCat.Data;
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

        public DateTime PublicationDate { get; set; }
    }
}
