using IMDB.Core.Applications.Common.Interfaces;
using System;

namespace IMDB.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
