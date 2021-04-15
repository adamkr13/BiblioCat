﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.TableJunctions.AuthorBook
{
    public class AuthorBookListItem
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int BookId { get; set; }
        public string Title { get; set; }
    }
}