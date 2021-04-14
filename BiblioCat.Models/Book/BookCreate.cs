using BiblioCat.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.Book
{
    public class BookCreate
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        public int ISBN { get; set; }

        [DisplayName("Genre")]
        public BookGenre GenreOfBook { get; set; }

        [DisplayName("Format")]
        public BookFormat FormatOfBook { get; set; }


        [DisplayName("Loaned To")]
        public string LoanedTo { get; set; }

        public string Narrator { get; set; }

        public string Translator { get; set; }

        public string Illustrator { get; set; }

        [DisplayName("Is A First Edition")]
        public bool IsFirstEdition { get; set; }

        [DisplayName("I Have Read It")]
        public bool IHaveRead { get; set; }

        [DisplayName("I Own It")]
        public bool IOwn { get; set; }        
    }
}
