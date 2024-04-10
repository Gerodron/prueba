using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.Booking.Queries.GetBookingsByType
{
    public class GetBookingsByTypeQuery : IGetBookingByTypeQuery
    {
        private readonly IDataBaseService _dataBaseService;

        public GetBookingsByTypeQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetBookingsByTypeModel>> Execute(string bookingType)
        {
            var result = await (from booking in _dataBaseService.Bookings
                                join customer in _dataBaseService.Customers
                                on booking.CustomerId equals customer.CustomerId
                                select new GetBookingsByTypeModel
                                {
                                    RegisterDate = booking.RegisterDate,
                                    Code = booking.Code,
                                    Type = booking.Type,    
                                    CustomerFullName = customer.FullName,
                                    CustomerDocumentNumber = customer.DocumentNumber,   
                                }
                                ).ToListAsync();

            return result;
        }
    }
}
