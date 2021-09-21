using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationBier.Models.RetailModels
{
    public class CreateRetail
    {
        //[MaxLength(1000, ErrorMessage = "Descriptions can have a maximum length of 1000 characters.")]
        public int RetailId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Retail Names MUST have a minimum length of 1 character.")]
        [MaxLength(100, ErrorMessage = "Retail Names MUST have a maximum length of 100 characters.")]
        public string RetailName { get; set; }

        
        public string Address { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsOnPremise { get; set; }
    }
}
