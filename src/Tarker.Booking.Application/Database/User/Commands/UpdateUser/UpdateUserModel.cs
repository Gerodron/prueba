﻿namespace Tarker.Booking.Application.Database.User.Commands.UpdateUser
{
    public class UpdateUserModel
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }
    }
}
