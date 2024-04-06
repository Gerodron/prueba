﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.User.Queries.GetAllUser
{
    public interface IGetAllUserQuery
    {
        Task<List<GetAllUserModel>> Execute();
    }
}
