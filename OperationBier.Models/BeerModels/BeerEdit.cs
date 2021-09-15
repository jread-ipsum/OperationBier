using OperationBier.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationBier.Models.BeerModels
{
    public class BeerEdit
    {
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public double ABV { get; set; }
        public bool IsRecommended { get; set; }
        public string BreweryName { get; set; }
        public string StyleName { get; set; }
    }
}
