using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.User.Commands.UpdateUserPassword
{
    public class UpdateUserPasswordCommand : IUpdateUserPasswordCommand
    {
        private readonly IDataBaseService _databaseService;

        public UpdateUserPasswordCommand(IDataBaseService dataBaseService)
        {
            _databaseService = dataBaseService; 
        }

        public async Task<bool> Execute(UpdateUserPasswordModel model)
        {
            var entity = await _databaseService.Users.FirstOrDefaultAsync(x => x.UserId == model.UserId);

            if (entity == null) 
                return false;

            entity.PassWord = model.Password;

            return await _databaseService.SaveAsync();
        }
    }
}
