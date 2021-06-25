using System;
using RetroCSV.Core.Interfaces;

namespace RetroCSV.Infrastructure.Services.SystemClock
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
