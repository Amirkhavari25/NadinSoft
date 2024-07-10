using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Domain.Entities
{
    public class AuthenticationReqBody
    {
        public string? UserName { get; set; }
        public string? Password{ get; set; }
    }
}
