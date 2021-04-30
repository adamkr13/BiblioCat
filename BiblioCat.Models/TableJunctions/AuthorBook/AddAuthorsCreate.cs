using BiblioCat.Models.Author;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.TableJunctions.AuthorBook
{
    public class AddAuthorsCreate
    {
        [Required]
        public int AuthorId { get; set; }

        public int BookId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Title { get; set; }

        [Required]
        public int[] Authors { get; set; }
    }
}
