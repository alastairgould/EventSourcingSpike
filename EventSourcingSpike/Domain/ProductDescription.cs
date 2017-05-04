using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSpike.Domain
{
    public class ProductDescription
    {
        public string LongDescription { get; private set; }
        public string ShortDescription { get; private set; }

        public ProductDescription(string longDescription, string shortDescription)
        {
            LongDescription = longDescription;
            ShortDescription = shortDescription;
        }
    }
}
