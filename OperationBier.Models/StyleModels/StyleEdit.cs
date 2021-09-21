using OperationBier.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationBier.Models.StyleModels
{
    public class StyleEdit
    {
        public int StyleId { get; set; }
        public string StyleName { get; set; }
        public string Description { get; set; }
        public int IBU { get; set; }
        public List<string> FoodPairing { get; set; }
        public string CountryOfOrigin { get; set; }
        public string RecommendedGlassware { get; set; }

        public virtual List<Beer> Beers { get; set; }

        public Guid AuthorId { get; set; }
    }
}
