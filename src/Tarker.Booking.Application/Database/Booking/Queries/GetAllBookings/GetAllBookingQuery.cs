using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.Booking.Queries.GetAllBookings
{
    public class GetAllBookingQuery : IGetAllBookingsQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetAllBookingQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService; 
            _mapper = mapper;   
        }

        public async Task<List<GetAllBookingModel>> Execute()
        {
            var result = await (from Booking in _dataBaseService.Bookings
                                join Customer in _dataBaseService.Customers
                                on Booking.CustomerId equals Customer.CustomerId
                                select new GetAllBookingModel
                                {
                                    BookingId = Booking.BookingId,
                                    Code = Booking.Code,
                                    RegisterDate = Booking.RegisterDate,
                                    Type = Booking.Type,
                                    CustomerFullName = Customer.FullName,
                                    CustomerDocumentNumber = Customer.DocumentNumber,
                                }
                                ).ToListAsync();
            return result;
        }
    }
}
