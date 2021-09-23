using OperationBier.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationBier.Models.BeerModels
{
    public class BeerRetailers
    {
        [Required]
        public int BeerId { get; set; }
        [Required]
        public int RetailId { get; set; }
    }
}
