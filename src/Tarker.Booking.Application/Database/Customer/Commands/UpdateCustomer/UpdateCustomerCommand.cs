using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Application.Database.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IUpdateCustomerCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateCustomerCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerModel> Execute(UpdateCustomerModel model)
        {
            var entity = _mapper.Map<CustomerEntity>(model);
            _dataBaseService.Customers.Update(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
