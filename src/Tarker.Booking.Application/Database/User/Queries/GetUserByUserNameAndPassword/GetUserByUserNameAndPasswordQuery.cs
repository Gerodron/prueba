using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.User.Queries.GetUserByUserNameAndPassword
{
    public class GetUserByUserNameAndPasswordQuery : IGetUserByUserNameAndPasswordQuery
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;

        public GetUserByUserNameAndPasswordQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _databaseService = dataBaseService;
            _mapper = mapper;   
        }

        public async Task<GetUserByUserNameAndPasswordModel> Execute(string userName, string passWord)
        {
            var entity = await _databaseService.Users.FirstOrDefaultAsync(x =>
            x.UserName == userName &&
            x.PassWord == passWord
            );

            return _mapper.Map<GetUserByUserNameAndPasswordModel>(entity);    
        }
    }
}
