using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.TableJunctions.SeriesAuthor
{
    public class SeriesAuthorCreate
    {
        [Required]
        public int SeriesId { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public string SeriesName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
