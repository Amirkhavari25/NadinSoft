using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Domain.Entities
{
    public class Users
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public ICollection<Products> Products{ get; set; } = new List<Products>();
    }
}
