using AutoMapper;
using Tarker.Booking.Application.Database.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.Database.Customer.Commands.UpdateCustomer;
<<<<<<< HEAD
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerById;
=======
>>>>>>> correcion-de-parametros-2
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomers;
using Tarker.Booking.Application.Database.User.Commands.CreateUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUser;
using Tarker.Booking.Application.Database.User.Queries.GetAllUser;
using Tarker.Booking.Application.Database.User.Queries.GetUserById;
using Tarker.Booking.Application.Database.User.Queries.GetUserByUserNameAndPassword;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Mapeos de Usuarios
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>();
            CreateMap<UserEntity, GetAllUserModel>();
            CreateMap<UserEntity, GetUserByUserNameAndPasswordModel>();
            #endregion

            CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetAllCustomersModel>();
            CreateMap<CustomerEntity, GetCustomerByIdModel>();
            CreateMap<CustomerEntity, GetCustomerByDocumentNumberModel>();
        }
    }
}
