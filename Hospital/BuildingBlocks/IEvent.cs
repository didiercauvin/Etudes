using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks
{
    public class IntegrationEvent : INotification
    {
        public IntegrationEvent(Guid id, DateTime occuredOn)
        {
            Id = id;
            OccuredOn = occuredOn;
        }

        public Guid Id { get; }
        public DateTime OccuredOn { get; }
    }

}
