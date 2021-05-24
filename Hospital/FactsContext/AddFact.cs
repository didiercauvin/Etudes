using BuildingBlocks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FactsContext
{
    public class AddFactRequest : IRequest
    {
        public Guid PatientId { get; set; }

        public class Handler : IRequestHandler<AddFactRequest>
        {
            public Task<Unit> Handle(AddFactRequest request, CancellationToken cancellationToken)
            {
                return Task.FromResult(Unit.Value);
            }
        }
    }
}
