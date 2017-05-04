using System;
using System.Collections.Generic;
using EventSourcingSpike.Domain;

namespace EventSourcingSpike.EventStore
{
    public class EventStore : IEventStore
    {
        public List<IEvent> EventStream { get; set; }

        public EventStore()
        {
            EventStream = new List<IEvent>();
        }

        public void AppendToStream(string streamId, IEnumerable<IEvent> events)
        {
            foreach(var evt in events)
            {
                System.Console.WriteLine(evt);
            }


            EventStream.AddRange(events);
        }

        public IEnumerable<IEvent> LoadStream(string streamId)
        {
            return EventStream;
        }
    }
}
