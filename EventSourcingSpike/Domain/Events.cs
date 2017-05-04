using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSpike.Domain
{
    public interface IEvent { }

    public class ProductDescriptionChanged : IEvent
    {
        public ProductDescription NewDescription { get; private set; }
        public ProductDescriptionChanged(ProductDescription newDescription)
        {
            NewDescription = newDescription;
        }
    }

    public class ProductNameChanged : IEvent
    {
        public string NewName { get; private set;  }
        public ProductNameChanged(string newName)
        {
            NewName = newName;
        }
    }

    public class ProductPriceChanged : IEvent
    {
        public Money NewPrice{ get; private set; }
        public ProductPriceChanged(Money newPrice)
        {
            NewPrice = newPrice;
        }
    }

    public class ProductRecommendedRetailPriceChanged : IEvent
    {
        public Money NewPrice { get; private set; }
        public ProductRecommendedRetailPriceChanged(Money newPrice)
        {
            NewPrice = newPrice;
        }
    }
}
