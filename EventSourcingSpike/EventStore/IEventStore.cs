using EventSourcingSpike.Domain;
using System.Collections.Generic;

namespace EventSourcingSpike.EventStore
{
    public interface IEventStore
    {
        IEnumerable<IEvent> LoadStream(string streamId);
        void AppendToStream(string streamId, IEnumerable<IEvent> events);
    }
}
