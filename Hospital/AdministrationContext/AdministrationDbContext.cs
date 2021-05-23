using Microsoft.EntityFrameworkCore;
using System;

namespace AdministrationContext
{
    public class AdministrationDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public AdministrationDbContext() : base(new DbContextOptionsBuilder<AdministrationDbContext>().UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyHospital;Trusted_Connection=True;").Options)
        {
            Database.OpenConnection();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Patient>().ToTable("Patients");
            builder.Entity<Patient>().HasKey(x => x.Id);
            builder.Entity<Patient>().Property<string>("Name").HasColumnName("Name");
            builder.Entity<Patient>().Property<string>("FirstName").HasColumnName("FirstName");
            builder.Entity<Patient>().Property<DateTime>("Birthdate").HasColumnName("Birthdate");
            builder.Entity<Patient>().Property<string>("Adresse1").HasColumnName("Adresse1");
            builder.Entity<Patient>().Property<string>("Adresse2").HasColumnName("Adresse2");
            builder.Entity<Patient>().Property<string>("PostalCode").HasColumnName("PostalCode");
            builder.Entity<Patient>().Property<string>("City").HasColumnName("City");
        }
    }
}
