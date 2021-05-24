using BuildingBlocks;
using System;

namespace AdministrationContext
{
    internal class PatientRegistered : IDomainEvent
    {
        public PatientRegistered(Guid id)
        {
            PatientId = id;
        }

        public Guid PatientId { get; }
    }
}