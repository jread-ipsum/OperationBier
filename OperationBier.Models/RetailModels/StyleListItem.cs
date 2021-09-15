using OperationBier.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationBier.Models.RetailModels
{
    public class StyleListItem
    {
        public int StyleId { get; set; }
        public string StyleName { get; set; }
        public List<Style> Styles { get; set; }

    }
}
