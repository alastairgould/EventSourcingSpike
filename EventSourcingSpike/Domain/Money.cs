using System;

namespace EventSourcingSpike.Domain
{
    public class Money
    {
        public Decimal Value { get; private set; }

        public Money(Decimal value)
        {
            Value = value;
        }
    }
}
