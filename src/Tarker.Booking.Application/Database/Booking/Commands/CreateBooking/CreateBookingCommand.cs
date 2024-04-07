using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Application.Database.Booking.Commands.CreateBooking
{
    public class CreateBookingCommand : ICreateBookingCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateBookingCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;   
        }
        
        public async Task<CreateBookingModel> Execute(CreateBookingModel model)
        {
            model.RegisterDate = DateTime.Now;

            var entity = _mapper.Map<BookingEntity>(model);
            await _dataBaseService.Bookings.AddAsync(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
