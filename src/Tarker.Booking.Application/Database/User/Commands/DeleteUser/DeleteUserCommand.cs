using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IDataBaseService _dataBaseService;
        public DeleteUserCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<bool> Execute(int userId)
        {
            var entity = await _dataBaseService.Users.FirstOrDefaultAsync(x => x.UserId == userId);

            if (entity == null) 
                return false;

            _dataBaseService.Users.Remove(entity);
            return await _dataBaseService.SaveAsync();
        }
    }
}
