using Parlem.Aplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parlem.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime CreateTime => DateTime.UtcNow;
    }
}
