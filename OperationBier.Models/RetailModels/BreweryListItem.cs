using OperationBier.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationBier.Models.RetailModels
{
    public class BreweryListItem
    {
        public int BreweryId { get; set; }
        public string BreweryName { get; set; }
        public List<Brewery> Brewery { get; set; }
        public bool IsStillInBusiness { get; set; }
    }
}
