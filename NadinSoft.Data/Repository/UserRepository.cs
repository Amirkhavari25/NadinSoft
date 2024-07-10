using Microsoft.EntityFrameworkCore;
using NadinSoft.Data.Context;
using NadinSoft.Domain.Entities;
using NadinSoft.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Data.Repository
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        private NadinSoftContext _context;
        public UserRepository(NadinSoftContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Users?> GetUserByUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Name == userName);
        }
    }
}
