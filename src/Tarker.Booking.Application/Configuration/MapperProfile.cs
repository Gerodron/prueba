﻿using AutoMapper;
using Tarker.Booking.Application.Database.User.Commands.CreateUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUser;
using Tarker.Booking.Application.Database.User.Queries.GetAllUser;
using Tarker.Booking.Application.Database.User.Queries.GetUserById;
using Tarker.Booking.Application.Database.User.Queries.GetUserByUserNameAndPassword;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>();
            CreateMap<UserEntity, GetAllUserModel>();
            CreateMap<UserEntity, GetUserByUserNameAndPasswordModel>();
        }
    }
}
