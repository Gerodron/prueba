﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocumentNumber
{
    public class GetCustomerByDocumentNumberQuery : IGetCustomerByDocumentNumberQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetCustomerByDocumentNumberQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetCustomerByDocumentNumberModel> Execute(string documentNumber)
        {
            var entity = await _dataBaseService.Customers.FirstOrDefaultAsync(x => x.DocumentNumber == documentNumber); 
            return _mapper.Map<GetCustomerByDocumentNumberModel>(entity);   
        }
    }
}
