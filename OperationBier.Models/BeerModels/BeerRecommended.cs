using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationBier.Models.BeerModels
{
    public class BeerRecommended
    {
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public bool? IsRecommended { get; set; }
    }
}
