﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocumentNumber
{
    public class GetCustomerByDocumentNumberModel
    {
        public int CustomerId { get; set; }

        public string FullName { get; set; }

        public string DocumentNumber { get; set; }
    }
}
