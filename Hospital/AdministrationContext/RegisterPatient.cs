using BuildingBlocks;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdministrationContext
{
    public class RegisterPatientRequest : IRequest
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public class Handler : IRequestHandler<RegisterPatientRequest>
        {
            private readonly AdministrationDbContext _context;

            public Handler(AdministrationDbContext context)
            {
                this._context = context;
            }

            public Task<Unit> Handle(RegisterPatientRequest request, CancellationToken cancellationToken)
            {
                var patient = Patient.Create(
                    request.Name,
                    request.FirstName,
                    request.Birthdate,
                    request.Adresse1,
                    request.Adresse2,
                    request.PostalCode,
                    request.City);

                _context.Add(patient);
                _context.SaveChanges();

                return Task.FromResult(Unit.Value);
            }
        }
    }
}
