using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Data
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }

        [Required]
        public string PublisherName { get; set; }

        [Required]
        public string Address { get; set; }

        [DisplayName("Publisher's Official Website")]
        public string PublisherWebsite { get; set; }

        [DisplayName("Authors with this Publisher")]
        public List<AuthorPublisher> AuthorsWithPublisher { get; set; } = new List<AuthorPublisher>();

        [DisplayName("Books Published")]
        public List<BookPublisher> SeriesOfBook { get; set; } = new List<BookPublisher>();
    }
}
