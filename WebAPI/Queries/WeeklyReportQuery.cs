using Paramore.Brighter;
using System;

namespace WebAPI.Queries
{
    public class WeeklyReportQuery : IRequest
    {
        public Guid Id { get; set; }

        public string Query { get; set; }

        public object Report { get; set; }
    }
}
