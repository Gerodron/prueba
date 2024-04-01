using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Persistence.Configuration
{
    public class BookingConfiguration
    {
        public BookingConfiguration(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.HasKey(x => x.BookingId);
            builder.Property(x => x.RegisterDate).IsRequired();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.UserId);

            builder
                .HasOne(x => x.Customer)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.CustomerId);

        }
    }
}
