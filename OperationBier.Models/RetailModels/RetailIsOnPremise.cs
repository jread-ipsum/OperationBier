using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationBier.Models.RetailModels
{
    public class RetailIsOnPremise
    {
        public int RetailId { get; set; }
        public string RetailName { get; set; }
        public bool? IsOnPremise { get; set; }
    }
}
