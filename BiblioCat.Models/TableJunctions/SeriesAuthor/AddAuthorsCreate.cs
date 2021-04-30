using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.TableJunctions.SeriesAuthor
{
    public class AddAuthorsCreate
    {
        [Required]
        public int SeriesId { get; set; }

        public int AuthorId { get; set; }

        [DisplayName("Name of Series")]
        public string SeriesName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public int[] Authors { get; set; }
    }
}
