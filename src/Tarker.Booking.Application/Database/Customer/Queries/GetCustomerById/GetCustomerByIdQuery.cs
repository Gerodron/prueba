using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IGetCustomerByIdQuery
    {
        private readonly IDataBaseService  _dataBaseService;
        private readonly IMapper _mapper;

        public GetCustomerByIdQuery(IDataBaseService dataBaseService, IMapper  mapper)
        {
            _dataBaseService =  dataBaseService;
            _mapper = mapper;   
        }

        public async Task<GetCustomerByIdModel> Execute(int customerId)
        {
            var entity = await _dataBaseService.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            return _mapper.Map<GetCustomerByIdModel>(entity);
        }
    }
}
