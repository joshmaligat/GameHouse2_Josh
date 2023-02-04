using GameHouse2_Josh.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                    CustContact = "9876 5432"
                },
                new Customer
                {
                    ID = 2,
                    CustName = "Kylie Kaili",
                    CustEmail = "kylie321@gmail.com",
                    CustContact = "9988 7766"
                }
            );
        }
    }
}
