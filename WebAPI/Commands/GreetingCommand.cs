using Paramore.Brighter;
using System;

namespace WebAPI.Commands
{
    public class GreetingCommand : IRequest
    {
        public GreetingCommand(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; private set; }
    }
}
