using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace OperationBier.Models.BreweryModels
{
    public class BreweryCreate
    {
        public int BreweryId { get; set; }
        [Required]
        public string BreweryName { get; set; }
        public string BreweryDescription { get; set; }
        public bool IsStillInBusiness { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CountryOfOrigin { get; set; }
    }
}
