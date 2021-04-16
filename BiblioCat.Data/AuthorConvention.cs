﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Data
{
    public class AuthorConvention
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        [Key, Column(Order =1)]
        [ForeignKey(nameof(Convention))]
        public int ConventionId { get; set; }
        public virtual Convention Convention { get; set; }
    }
}
