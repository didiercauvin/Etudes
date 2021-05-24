using BuildingBlocks;
using System;

namespace AdministrationContext
{
    public class Patient : AggregateRoot
    {
        public string Name { get; }
        public string FirstName { get; }
        public DateTime Birthdate { get; }
        public string Adresse1 { get; }
        public string Adresse2 { get; }
        public string PostalCode { get; }
        public string City { get; }

        private Patient(
            string name,
            string firstName,
            DateTime birthdate,
            string adresse1,
            string adresse2,
            string postalCode,
            string city)
        {
            Name = name;
            FirstName = firstName;
            Birthdate = birthdate;
            Adresse1 = adresse1;
            Adresse2 = adresse2;
            PostalCode = postalCode;
            City = city;

            ApplyChange(new PatientRegistered(Id));
        }

        public static Patient Create(
            string name,
            string firstName,
            DateTime birthdate,
            string adresse1,
            string adresse2,
            string postalCode,
            string city)
        {
            return new Patient(name, firstName, birthdate, adresse1, adresse2, postalCode, city);
        }

        protected override void RegisterAppliers()
        {
            RegisterApplier<PatientRegistered>(this.Apply);
        }

        private void Apply(PatientRegistered patient)
        {
            
        }
    }
}
