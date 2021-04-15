using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string ISBN { get; set; }

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

        [DisplayName("Author(s) of Book")]
        public List<AuthorBook> AuthorsOfBook { get; set; } = new List<AuthorBook>();

        [DisplayName("Published By")]
        public List<BookPublisher> PublishersOfBook { get; set; } = new List<BookPublisher>();

        [DisplayName("Part of Series")]
        public List<SeriesBook> SeriesOfBook { get; set; } = new List<SeriesBook>();
    }

    public enum BookGenre
    {
        Action,
        Crime,
        Fantasy, 
        Horror,
        [Description("Paranormal Romance")]
        ParanormalRomance,
        Romance,
        [Description("Science Fiction")]
        SciFi,
        Western,
        NonFiction
    }

    public enum BookFormat
    {        
        Audio,
        Chapbook,
        Hardcover,
        [Description("Trade Paperback")]
        TradePaper,
        [Description("E-book")]
        Ebook,
        [Description("Mass Market Paperback")]
        MassMarketPaperback
    }
}
