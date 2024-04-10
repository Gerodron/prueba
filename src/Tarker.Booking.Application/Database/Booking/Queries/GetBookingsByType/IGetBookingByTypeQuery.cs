using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.Booking.Queries.GetBookingsByType
{
    public interface IGetBookingByTypeQuery
    {
        Task<List<GetBookingsByTypeModel>> Execute(string bookingType);
    }
}
