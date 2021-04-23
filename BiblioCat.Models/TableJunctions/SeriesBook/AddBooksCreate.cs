using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.TableJunctions.SeriesBook
{
    public class AddBooksCreate
    {
        [Required]
        public int SeriesId { get; set; }

        [DisplayName("Name of Series")]
        public string SeriesName { get; set; }

        public int BookId { get; set; }

        public string Title { get; set; }

        [Required]
        public int[] Titles { get; set; }
    }
}
