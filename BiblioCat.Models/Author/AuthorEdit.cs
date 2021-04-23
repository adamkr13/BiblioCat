using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.Author
{
    public class AuthorEdit
    {
        public int AuthorId { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Patreon Site")]
        public string Patreon { get; set; }

        [DisplayName("Official Website")]
        public string OfficialWebsite { get; set; }

        [DisplayName("Amazon Page")]
        public string AmazonPage { get; set; }

        [DisplayName("Goodreads Page")]
        public string GoodreadsPage { get; set; }

        [DisplayName("Twitter Handle")]
        public string TwitterHandle { get; set; }
    }
}
