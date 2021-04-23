using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.TableJunctions.AuthorBook
{
    public class AuthorBookCreate
    {
        [Required]
        public int AuthorId { get; set; }
        
        [Required]
        public int BookId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public int []Titles { get; set; }
    }
}
