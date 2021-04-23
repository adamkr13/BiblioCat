using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.Publisher
{
    public class PublisherEdit
    {
        public int PublisherId { get; set; }

        [Required]
        [DisplayName("Publisher")]
        public string PublisherName { get; set; }

        [Required]
        public string Address { get; set; }

        [DisplayName("Official Website")]
        public string PublisherWebsite { get; set; }
    }
}
