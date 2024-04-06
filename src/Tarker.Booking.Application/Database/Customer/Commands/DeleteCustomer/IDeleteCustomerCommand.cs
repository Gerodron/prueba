﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.Customer.Commands.DeleteCustomer
{
    public interface IDeleteCustomerCommand
    {
        Task<bool> Execute(int customerId);
    }
}
