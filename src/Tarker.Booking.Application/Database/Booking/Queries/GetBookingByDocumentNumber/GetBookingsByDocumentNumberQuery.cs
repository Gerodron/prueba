using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.Booking.Queries.GetBookingByDocumentNumber
{
    public class GetBookingsByDocumentNumberQuery : IGetBookingsByDocumentNumberQuery
    {
        private readonly IDataBaseService _dataBaseService;

        public GetBookingsByDocumentNumberQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetBookinsByDocumentNumberModel>> Execute(string documentNumber)
        {
            var result = await (from booking in _dataBaseService.Bookings
                                  join customer in _dataBaseService.Customers
                                  on booking.CustomerId equals customer.CustomerId
                                  where customer.DocumentNumber == documentNumber
                                  select new GetBookinsByDocumentNumberModel
                                  {
                                      RegisterDate = booking.RegisterDate,
                                      Code = booking.Code,
                                      Type = booking.Type
                                  }).ToListAsync();

            return result;
        }

    }
}
