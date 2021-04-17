using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.TableJunctions.BookPublisher
{
    public class BookPublisherDetail
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int PublisherId { get; set; }

        [DisplayName("Publisher")]
        public string PublisherName { get; set; }
    }
}
