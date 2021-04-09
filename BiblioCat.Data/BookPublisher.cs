using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Data
{
    public class BookPublisher
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Series))]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        [Key, Column(Order = 1)]
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
