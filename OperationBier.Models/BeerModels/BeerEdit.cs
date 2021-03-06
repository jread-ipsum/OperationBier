using OperationBier.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationBier.Models.BeerModels
{
    public class BeerEdit
    {
        [Required]
        public int BeerId { get; set; }
        [Required]
        public string BeerName { get; set; }
        [Required]
        public double ABV { get; set; }
        public bool IsRecommended { get; set; }
        public int? BreweryId { get; set; }
        public int? StyleId { get; set; }
    }
}
