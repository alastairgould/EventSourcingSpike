using EventSourcingSpike.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSpike
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventStore = new EventStore.EventStore();

            var productAggregate = new ProductAggregate();

            productAggregate.ChangeName("Test Product 1");
            productAggregate.ChangeDescription(new ProductDescription("LongDescription", "ShortDescription"));
            productAggregate.ChangePrice(new Money(2));
            productAggregate.ChangeRecommendedRetailPrice(new Money(3));

            eventStore.AppendToStream("1", productAggregate.UncommittedEvents);


            var eventStream = eventStore.LoadStream("1");
            var productAggregate1 = new ProductAggregate(eventStream);


            System.Console.ReadKey();

            productAggregate1.ChangeName("Test Product 2");
            eventStore.AppendToStream("1", productAggregate1.UncommittedEvents);


            var eventStream1 = eventStore.LoadStream("1");
            var productAggregate2 = new ProductAggregate(eventStream1);

            System.Console.ReadKey();
        }
    }
}
