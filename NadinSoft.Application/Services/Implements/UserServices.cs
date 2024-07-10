using NadinSoft.Application.Services.Interfaces;
using NadinSoft.Domain.Entities;
using NadinSoft.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.Services.Implements
{
    public class UserServices : IUserService
    {
        private IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Users?> GetUserByUserName(string userName)
        {
            return await _userRepository.GetUserByUserName(userName);
        }
    }
}
