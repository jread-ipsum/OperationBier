using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationBier.Data
{
    public class Beer
    {
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public double ABV { get; set; }
        public bool? IsRecommended { get; set; }

        [ForeignKey(nameof(Style))]
        public int StyleId { get; set; }
        public virtual Style Style { get; set; }

        [ForeignKey(nameof(Brewery))]
        public int BreweryId { get; set; }
        public virtual Brewery Brewery { get; set; }

        public virtual List<Retail> Retailers { get; set; }

        public Guid AuthorId { get; set; }

    }
}
