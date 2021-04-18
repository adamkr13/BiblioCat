using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.TableJunctions.AuthorPublisher
{
    public class AuthorPublisherDetail
    {
        public int AuthorId { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        public int PublisherId { get; set; }

        [DisplayName("Publisher")]
        public string PublisherName { get; set; }
    }
}
