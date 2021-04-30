using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Models.TableJunctions.AuthorConvention
{
    public class AddConventionsCreate
    {
        [Required]
        public int AuthorId { get; set; }
        
        public int ConventionId { get; set; }

        [DisplayName("Convention Name")]
        public string ConventionName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public int[] Conventions { get; set; }
    }
}
