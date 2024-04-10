﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Tarker.Booking.Application.Configuration;
using Tarker.Booking.Application.Database.Booking.Commands.CreateBooking;
using Tarker.Booking.Application.Database.Booking.Queries.GetBookingByDocumentNumber;
using Tarker.Booking.Application.Database.Booking.Queries.GetBookingsByType;
using Tarker.Booking.Application.Database.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.Database.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.Database.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomers;
using Tarker.Booking.Application.Database.User.Commands.CreateUser;
using Tarker.Booking.Application.Database.User.Commands.DeleteUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.Database.User.Queries.GetAllUser;
using Tarker.Booking.Application.Database.User.Queries.GetUserById;
using Tarker.Booking.Application.Database.User.Queries.GetUserByUserNameAndPassword;

namespace Tarker.Booking.Application
{
    public static class DependencyInjectionService 
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            var mapper = new MapperConfiguration(config => {

                config.AddProfile(new MapperProfile());

            });

            services.AddSingleton(mapper.CreateMapper());

            #region Operaciones de Usuario 
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>(); 
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>(); 
            services.AddTransient<IUpdateUserPasswordCommand, UpdateUserPasswordCommand>();
            services.AddTransient<IGetAllUserQuery, GetAllUserQuery>();
            services.AddTransient<IGetUserByIdQuery , GetUserByIdQuery>();  
            services.AddTransient<IGetUserByUserNameAndPasswordQuery , GetUserByUserNameAndPasswordQuery>();
            #endregion

            #region Operaciones de Clientes
            services.AddTransient<ICreateCustomerCommand, CreateCustomerCommand>(); 
            services.AddTransient<IUpdateCustomerCommand , UpdateCustomerCommand>();    
            services.AddTransient<IDeleteCustomerCommand, DeleteCustomerCommand>();
            services.AddTransient<IGetAllCustomersQuery , GetAllCustomersQuery>();
            services.AddTransient<IGetCustomerByIdQuery, GetCustomerByIdQuery>();
            services.AddTransient<IGetCustomerByDocumentNumberQuery, GetCustomerByDocumentNumberQuery>();
            #endregion

            services.AddTransient<ICreateBookingCommand, CreateBookingCommand>();
            services.AddTransient<IGetAllCustomersQuery, GetAllCustomersQuery>();
            services.AddTransient<IGetBookingsByDocumentNumberQuery, GetBookingsByDocumentNumberQuery>();
            services.AddTransient<IGetBookingByTypeQuery, GetBookingsByTypeQuery>();

            return services;
        }
    }
}
