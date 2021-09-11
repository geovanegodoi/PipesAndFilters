using Paramore.Brighter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Queries
{
    public class WeeklyReportQuery : IRequest
    {
        public Guid Id { get; set; }

        public string Query { get; set; }

        public object Report { get; set; }
    }
}
