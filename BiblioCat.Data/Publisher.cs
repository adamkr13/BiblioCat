using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Data
{
    public class Publisher
    {
        public int PublisherId { get; set; }

        [Required]
        public string PublisherName { get; set; }

        [Required]
        public string Address { get; set; }


        public string PublisherWebsite { get; set; }

    }
}
