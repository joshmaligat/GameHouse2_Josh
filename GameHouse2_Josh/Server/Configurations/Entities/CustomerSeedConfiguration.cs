using GameHouse2_Josh.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GameHouse2_Josh.Server.Configurations.Entities
{
    public class CustomerSeedConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    ID = 1,
                    CustName = "Jerome Tan",
                    CustEmail = "jerome123@gmail.com",
                    CustContact = "9876 5432",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Customer
                {
                    ID = 2,
                    CustName = "Kylie Kaili",
                    CustEmail = "kylie321@gmail.com",
                    CustContact = "9988 7766",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
            );
        }
    }
}
