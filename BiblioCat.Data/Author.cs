﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Data
{
    public class Author
    {
        [Key]        
        public int AuthorId { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }        

        [DisplayName("Patreon Site")]
        public string Patreon { get; set; }

        [DisplayName("Official Website")]
        public string OfficialWebsite { get; set; }

        [DisplayName("Author's Amazon Page")]
        public string AmazonPage { get; set; }

        [DisplayName("Author's Goodreads Page")]
        public string GoodreadsPage { get; set; }

        [DisplayName("Author's Twitter Handle")]
        public string TwitterHandle { get; set; }

        [DisplayName("Books by Author")]
        public virtual List<AuthorBook> BooksByAuthor { get; set; } = new List<AuthorBook>();

        [DisplayName("Conventions Attending")]
        public virtual List<AuthorConvention> ConventionsAttending { get; set; } = new List<AuthorConvention>();

        [DisplayName("Published By")]
        public virtual List<AuthorPublisher> AuthorPublishedBy { get; set; } = new List<AuthorPublisher>();

        [DisplayName("Series Written")]
        public virtual List<SeriesAuthor> SeriesWritten { get; set; } = new List<SeriesAuthor>();
    }
}
