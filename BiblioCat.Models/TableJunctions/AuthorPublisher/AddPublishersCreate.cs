using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.TableJunctions.AuthorPublisher
{
    public class AddPublishersCreate
    {
        [Required]
        public int AuthorId { get; set; }

        public int PublisherId { get; set; }

        public string PublisherName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public int[] Publishers { get; set; }
    }
}
