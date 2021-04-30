using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.TableJunctions.AuthorPublisher
{
    public class AddAuthorsCreate
    {
        public int AuthorId { get; set; }

        [Required]
        public int PublisherId { get; set; }

        [DisplayName("Publisher Name")]
        public string PublisherName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public int[] Authors { get; set; }
    }
}
