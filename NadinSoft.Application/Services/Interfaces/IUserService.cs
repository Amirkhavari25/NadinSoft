using NadinSoft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<Users?> GetUserByUserName(string userName);
    }
}
