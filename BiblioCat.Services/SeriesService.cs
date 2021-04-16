using BiblioCat.Data;
using BiblioCat.Models.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCat.Services
{
    public class SeriesService
    {
        private readonly Guid _userId;

        public SeriesService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<SeriesListItem> GetSeries()
        {
            using (var ctx = new ApplicationDbContext())
            {

            }
        }
    }
}
