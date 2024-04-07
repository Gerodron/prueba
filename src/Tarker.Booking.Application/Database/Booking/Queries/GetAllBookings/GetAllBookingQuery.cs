using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.Booking.Queries.GetAllBookings
{
    public class GetAllBookingQuery
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
            var entities = await _dataBaseService.Bookings.ToListAsync();
            return _mapper.Map<List<GetAllBookingModel>>(entities);
        }
    }
}
