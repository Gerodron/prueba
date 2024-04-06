using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Persistence.Configuration
{
    public class CustomerConfiguration
    {
        public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.HasKey(x => x.CustomerId);
            builder.Property(x => x.FullName).IsRequired();
            builder.Property(x => x.DocumentNumber).IsRequired();

            builder
                .HasMany(x => x.Bookings)
                .WithOne(x => x.Customer)
                .HasPrincipalKey(x => x.CustomerId);
        }
    }
}
