using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Data
{
    public class Series
    {
        [Key]
        public int SeriesId { get; set; }

        [Required]
        [DisplayName("Name of Series")]
        public string SeriesName { get; set; }

        [DisplayName("Series Description")]
        public string SeriesDescription { get; set; }

        [DisplayName("Authors Contributing to the Series")]
        public List<SeriesAuthor> AuthorsInSeries { get; set; } = new List<SeriesAuthor>();

        [DisplayName("Books in the Series")]
        public List<SeriesBook> SeriesOfBook { get; set; } = new List<SeriesBook>();
    }    
}
