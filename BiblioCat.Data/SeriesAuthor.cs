using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Data
{
    public class SeriesAuthor
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Series))]
        public int SeriesId { get; set; }
        public virtual Series Series { get; set; }

        [Key, Column(Order =1)]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
