using System;

namespace AorangiPeak.Domain.Core.Model
{
    public class TableBookingChildren : AggregateRootBase
    {
        public string Value { get; private set; }
        public string Text { get; private set; }
        public int Order { get; private set; }

        public TableBookingChildren(Guid id, string value, string text, int order)
        {
            this.Id = id;
            this.Value = value;
            this.Text = text;
            this.Order = order;
        }
    }
}
