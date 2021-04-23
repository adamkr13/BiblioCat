﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.Convention
{
    public class ConventionEdit
    {
        public int ConventionId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [DisplayName("Start")]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayName("End")]
        public DateTime EndDate { get; set; }

        public string Hotel { get; set; }

        public string Website { get; set; }
    }
}
