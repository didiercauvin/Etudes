using BuildingBlocks;
using System;

namespace AdministrationContext
{
    public class RegisterPatientCommand : ICommand
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public class Handler : ICommandHandler<RegisterPatientCommand>
        {
            private readonly AdministrationDbContext _context;

            public Handler(AdministrationDbContext context)
            {
                this._context = context;
            }
            public void Handle(RegisterPatientCommand command)
            {
                var patient = Patient.Create(
                    command.Name,
                    command.FirstName,
                    command.Birthdate,
                    command.Adresse1,
                    command.Adresse2,
                    command.PostalCode,
                    command.City);

                _context.Add(patient);
                _context.SaveChanges();
            }
        }
    }
}
