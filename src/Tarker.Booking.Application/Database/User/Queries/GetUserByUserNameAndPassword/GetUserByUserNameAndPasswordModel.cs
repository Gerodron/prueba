﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.User.Queries.GetUserByUserNameAndPassword
{
    public class GetUserByUserNameAndPasswordModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }
    }
}
