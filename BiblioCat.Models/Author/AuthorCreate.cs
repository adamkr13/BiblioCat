using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.Author
{
    public class AuthorCreate
    {
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [DisplayName("Official Website")]
        public string OfficialWebsite { get; set; }

        [DisplayName("Author's Amazon Page")]
        public string AmazonPage { get; set; }

        [DisplayName("Author's Goodreads Page")]
        public string GoodreadsPage { get; set; }

        [DisplayName("Author's Twitter Handle")]
        public string TwitterHandle { get; set; }
    }
}
