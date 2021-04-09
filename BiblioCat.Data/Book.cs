using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Data
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        public int ISBN { get; set; }

        public string LoanedTo { get; set; }

        public string Narrator { get; set; }

        public string Translator { get; set; }

        public string Illustrator { get; set; }

        public bool IsFirstEdition { get; set; }

        public bool IHaveRead { get; set; }
    }
}
