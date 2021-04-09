using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Data
{
    public class Author
    {
        [Key]        
        public int AuthorId { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string OfficialWebsite { get; set; }
        public string AmazonPage { get; set; }
        public string GoodreadsPage { get; set; }
        public string TwitterHandle { get; set; }

        public virtual ICollection<AuthorConvention> Conventions { get; set; }



    }
}
