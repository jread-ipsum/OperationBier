using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationBier.Data
{
    public class Retail
    {
        public int RetailId { get; set; }
        public string RetailName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsOnPremise { get; set; }
        public virtual List<Beer> Beers { get; set; }
        public Guid AuthorId { get; set; }
    }
}
