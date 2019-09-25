using System;
using BeComfy.Common.Messages;
using Newtonsoft.Json;

namespace BeComfy.Services.Flights.Messages.Commands
{
    public class DeleteFlight : ICommand
    {
        public Guid Id { get; set; }

        [JsonConstructor]
        public DeleteFlight(Guid id)
        {
            Id = id;
        }
    }
}