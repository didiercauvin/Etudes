using BuildingBlocks;
using System;

namespace AdministrationIntegrationEvents
{
    public class PatientRegisteredIntegrationEvent : IntegrationEvent
    {
        public PatientRegisteredIntegrationEvent(Guid id, DateTime occuredOn, Guid patientId) : base(id, occuredOn)
        {
            PatientId = patientId;
        }

        public Guid PatientId { get; }
    }
}
