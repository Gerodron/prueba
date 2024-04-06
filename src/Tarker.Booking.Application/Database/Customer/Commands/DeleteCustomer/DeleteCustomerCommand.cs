using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Application.Database.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IDeleteCustomerCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public DeleteCustomerCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
             _dataBaseService = dataBaseService;
            _mapper = mapper;   
        }

        public async Task<bool> Execute(int customerId)
        {
            var entity = await _dataBaseService.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);

            if (entity == null)
                return false;

            _dataBaseService.Customers.Remove(entity);
            return await _dataBaseService.SaveAsync();
            
        }
    }
}
