using System;

namespace AorangiPeak.Dto.TableBookingDto
{
    public class TableBookingTimeDto : IOutputDto
    {
        public string TimeValue { get; set; }
        public string TimeText { get; set; }
        public string Season { get; set; }
        public int TimeOrder { get; set; }
        public Guid Id { get; set; }
    }
}
