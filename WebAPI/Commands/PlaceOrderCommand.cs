using Paramore.Brighter;
using System;

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
