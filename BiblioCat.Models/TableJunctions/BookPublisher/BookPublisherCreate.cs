using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.TableJunctions.BookPublisher
{
    public class BookPublisherCreate
    {
        [Required]
        public int BookId { get; set; }

        public string Title { get; set; }

        [Required]
        public int PublisherId { get; set; }

        [DisplayName("Publisher")]
        public string PublisherName { get; set; }
    }
}
