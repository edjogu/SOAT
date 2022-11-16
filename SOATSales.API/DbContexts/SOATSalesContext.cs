using Microsoft.EntityFrameworkCore;
using SOATSales.API.Entities;
using System;

namespace SOATSales.API.DbContexts
{
    public class SOATSalesContext : DbContext
    {
        public SOATSalesContext(DbContextOptions<SOATSalesContext> options)
           : base(options)
        {
        }

        public DbSet<Policy> Policies { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Policy>().HasData(
                new Policy()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9888"),
                    CityId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                    FirstName = "Raul",
                    LastName = "Perez",
                    PolicyNumber = "14575000853560",
                    DateOfIssue = new DateTime(2021, 4, 10),
                    DateOfStart = new DateTime(2021, 4, 11),
                    DateOfExpiration = new DateTime(2022, 4, 10),
                    LicencePlate = "ABC547"
                },
                new Policy()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    CityId = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                    FirstName = "Nancy",
                    LastName = "Garcerant",
                    PolicyNumber = "14579000853599",
                    DateOfIssue = new DateTime(2022, 5, 13),
                    DateOfStart = new DateTime(2022, 5, 14),
                    DateOfExpiration = new DateTime(2023, 5, 13),
                    LicencePlate = "ABC888"
                },
                new Policy()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    CityId = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                    FirstName = "Pedro",
                    LastName = "Pabon",
                    PolicyNumber = "34579000850000",
                    DateOfIssue = new DateTime(2022, 6, 14),
                    DateOfStart = new DateTime(2022, 6, 15),
                    DateOfExpiration = new DateTime(2023, 6, 14),
                    LicencePlate = "ABC999"
                },
                new Policy()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    CityId = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                    FirstName = "Arnold",
                    LastName = "Hernandez",
                    PolicyNumber = "88769000850022",
                    DateOfIssue = new DateTime(2021, 2, 15),
                    DateOfStart = new DateTime(2021, 2, 16),
                    DateOfExpiration = new DateTime(2022, 2, 15),
                    LicencePlate = "ABC007"
                }                
                );

            modelBuilder.Entity<City>().HasData(
               new City
               {
                   Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   CityName = "Bogota",
                   IsForSOAT = true
               },
               new City
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                   CityName = "Cartagena",
                   IsForSOAT = true
               },
               new City
               {
                   Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                   CityName = "Barranquilla",
                   IsForSOAT = false
               },
               new City
               {
                   Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                   CityName = "Medellin" ,
                   IsForSOAT = true
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
