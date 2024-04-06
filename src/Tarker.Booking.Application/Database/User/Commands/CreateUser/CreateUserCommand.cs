using AutoMapper;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.Database.User.Commands.CreateUser
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateUserCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService; 
            _mapper = mapper;   
        }

        public async Task<CreateUserModel> Execute(CreateUserModel model)
        {
            try
            {
                var entity = _mapper.Map<UserEntity>(model);
                await _dataBaseService.Users.AddAsync(entity);
                await _dataBaseService.SaveAsync();

                return model;
            }
            catch (AutoMapperMappingException ex)
            {
                // Manejar la excepción de mapeo de AutoMapper
                // Puedes registrar el error, lanzar una excepción personalizada, etc.
                // Aquí tienes un ejemplo de cómo imprimir el mensaje de la excepción:
                Console.WriteLine($"Error de mapeo de AutoMapper: {ex.Message}");
                throw; // Puedes relanzar la excepción si quieres propagarla
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones que puedan ocurrir durante la ejecución del método
                // Puedes registrar el error, lanzar una excepción personalizada, etc.
                Console.WriteLine($"Se produjo un error durante la ejecución: {ex.Message}");
                throw; // Puedes relanzar la excepción si quieres propagarla
            }
        }

    }
}
