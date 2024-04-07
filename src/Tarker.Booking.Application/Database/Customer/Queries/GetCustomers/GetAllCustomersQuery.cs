using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.Customer.Queries.GetCustomers
{
    public class GetAllCustomersQuery : IGetAllCustomersQuery
    {
        private readonly IDataBaseService _dataBaseService;   
        private readonly IMapper _mapper;

        public GetAllCustomersQuery(IDataBaseService dataBaseService, IMapper  mapper)
        {
            _dataBaseService = dataBaseService; 
            _mapper = mapper;
        }

        public async Task<List<GetAllCustomersModel>> Execute(int customerId)
        {
            var entity = await _dataBaseService.Customers.ToListAsync();
            return _mapper.Map<List<GetAllCustomersModel>>(entity);   
            
        }

    }
}
