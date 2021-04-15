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
        
        [DisplayName("Author Last Name")]
        public string LastName { get; set; }

        [DisplayName("Author First Name")]
        public string FirstName { get; set; }

        public List<int> AuthorIds { get; set; }

        [DisplayName("Author Last Name")]
        public List<string> LastNames { get; set; }

        [DisplayName("Author First Name")]
        public List<string> FirstNames { get; set; }
    }
}
