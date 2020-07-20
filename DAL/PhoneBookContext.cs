using PhoneBookWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PhoneBookWebApp.DAL
{
    public class PhoneBookContext: DbContext
    {
        public PhoneBookContext(): base("PhoneBookContext")
        {

        }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Address>()
            //    .HasRequired<People>(s => s.People)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Address>()
            //   .HasRequired<Country>(s => s.Country)
            //   .WithMany()
            //   .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Address>()
            //   .HasRequired<State>(s => s.State)
            //   .WithMany()
            //   .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Address>()
            //   .HasRequired<City>(s => s.City)
            //   .WithMany()
            //   .WillCascadeOnDelete(false);

            //modelBuilder.Entity<State>()
            //   .HasRequired<Country>(s => s.Country)
            //   .WithMany()
            //   .WillCascadeOnDelete(false);

            //modelBuilder.Entity<City>()
            //   .HasRequired<State>(s => s.State)
            //   .WithMany()
            //   .WillCascadeOnDelete(false);

        }
    }
}