﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.Booking.Queries.GetBookingByDocumentNumber
{
    public class GetBookinsByDocumentNumberModel
    {
        public DateTime RegisterDate { get; set; }

        public string Code { get; set; }

        public string Type { get; set; }
    }
}
