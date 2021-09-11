using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Infrastructure
{
    public interface IRepository
    {
        object ExecuteQuery(string query);
    }

    public class Repository : IRepository
    {
        public object ExecuteQuery(string query) => "";
    }
}
