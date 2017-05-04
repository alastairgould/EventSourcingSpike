using System.Collections.Generic;



namespace EventSourcingSpike.Domain
{
    public class ProductAggregate
    {
        public Money Price { get; private set; }
        public Money RecommendedRetailPrice { get; private set; }
        public string Name { get; private set; }
        public ProductDescription Description { get; private set; }

        private readonly List<IEvent> _uncommittedEvents = new List<IEvent>();
        public IEnumerable<IEvent> UncommittedEvents => _uncommittedEvents.AsReadOnly();

        public ProductAggregate()
        {

        }

        public ProductAggregate(IEnumerable<IEvent> events)
        {
            ApplyEvents(events);
        }

        public void ChangeName(string name)
        {
            RaiseEvent(new ProductNameChanged(name));
        }

        public void ChangePrice(Money price)
        {
            RaiseEvent(new ProductPriceChanged(price));
        }

        public void ChangeRecommendedRetailPrice(Money price)
        {
            RaiseEvent(new ProductRecommendedRetailPriceChanged(price));
        }

        public void ChangeDescription(ProductDescription description)
        {
            RaiseEvent(new ProductDescriptionChanged(description));
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

        public void RaiseEvent(IEvent evt)
        {
            When((dynamic)evt);
            _uncommittedEvents.Add(evt);
        }
    }
}
