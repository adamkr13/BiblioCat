using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.Series
{
    public class SeriesCreate
    {
        [Required]
        [DisplayName("Name of Series")]
        public string SeriesName { get; set; }

        [DisplayName("Series Description")]
        public string SeriesDescription { get; set; }
    }
}
