using System.Collections.Generic;

namespace EventSourcingSpike.Domain
{
    public class ProductAggregate
    {
        private readonly List<IEvent> _uncommittedEvents = new List<IEvent>();
        public IEnumerable<IEvent> UncommittedEvents => _uncommittedEvents.AsReadOnly();

        public Money Price { get; private set; }
        public Money RecommendedRetailPrice { get; private set; }
        public string Name { get; private set; }
        public ProductDescription Description { get; private set; }

        public ProductAggregate()
        {

        }

        public ProductAggregate(IEnumerable<IEvent> events)
        {
            ApplyEvents(events);
        }

        public void ChangeName(string name)
        {
            ApplyEvent(new ProductNameChanged(name));
        }

        public void ChangePrice(Money price)
        {
            ApplyEvent(new ProductPriceChanged(price));
        }

        public void ChangeRecommendedRetailPrice(Money price)
        {
            ApplyEvent(new ProductRecommendedRetailPriceChanged(price));
        }

        public void ChangeDescription(ProductDescription description)
        {
            ApplyEvent(new ProductDescriptionChanged(description));
        }

        private void When(ProductNameChanged evt)
        {
            Name = evt.NewName;
        }

        private void When(ProductDescriptionChanged evt)
        {
            Description = evt.NewDescription;
        }

        private void When(ProductPriceChanged evt)
        {
            Price = evt.NewPrice;
        }

        private void When(ProductRecommendedRetailPriceChanged evt)
        {
            RecommendedRetailPrice = evt.NewPrice;
        }

        private void ApplyEvents(IEnumerable<IEvent> events)
        {
            foreach (var evt in events)
            {
                When((dynamic)evt);
            }
        }

        public void ApplyEvent(IEvent evt)
        {
            When((dynamic)evt);
            _uncommittedEvents.Add(evt);
        }
    }
}
