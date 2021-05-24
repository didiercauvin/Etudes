using AdministrationIntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FactsContext
{
    public class PatientRegisteredEventHandler : INotificationHandler<PatientRegisteredIntegrationEvent>
    {
        private readonly IMediator _mediator;

        public PatientRegisteredEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Handle(PatientRegisteredIntegrationEvent notification, CancellationToken cancellationToken)
        {
            _mediator.Send(new AddFactRequest { PatientId = notification.PatientId }, cancellationToken);

            return Task.CompletedTask;
        }
    }
}
