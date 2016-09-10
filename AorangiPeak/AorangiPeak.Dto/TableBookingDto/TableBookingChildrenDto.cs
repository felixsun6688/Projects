﻿using System;

namespace AorangiPeak.Dto.TableBookingDto
{
    public class TableBookingChildrenDto : IOutputDto
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
        public Guid Id { get; set; }
    }
}