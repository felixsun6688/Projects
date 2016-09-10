using System;

namespace AorangiPeak.Domain.Core.Model
{
    public class TableBookingTime : AggregateRootBase
    {
        public string TimeValue { get; private set; }
        public string TimeText { get; private set; }
        public string Season { get; private set; }
        public int TimeOrder { get; private set; }

        public TableBookingTime(Guid id, string timevalue, string timetext, string season, int timeorder)
        {
            this.Id = id;
            this.TimeValue = timevalue;
            this.TimeText = timetext;
            this.Season = season;
            this.TimeOrder = timeorder;
        }
    }
}
