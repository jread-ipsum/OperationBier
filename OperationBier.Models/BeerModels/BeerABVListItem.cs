using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationBier.Models.BeerModels
{
    public class BeerABVListItem
    {
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        [Required]
        public double ABV { get; set; }
    }
}
