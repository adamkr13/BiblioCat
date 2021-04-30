using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.TableJunctions.BookPublisher
{
    public class AddBooksCreate
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        [Required]
        public int PublisherId { get; set; }

        [DisplayName("Publisher Name")]
        public string PublisherName { get; set; }

        [Required]
        public int[] Books { get; set; }
    }
}
