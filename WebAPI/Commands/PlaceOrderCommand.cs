using Paramore.Brighter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Commands
{
    public class PlaceOrderCommand : IRequest
    {
        public Guid Id { get; set; }

        public PlaceOrderCommand(Guid id)
        {
            Id = id;
        }
    }
}
