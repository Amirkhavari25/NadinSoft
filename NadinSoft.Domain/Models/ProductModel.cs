using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Domain.Models
{
    public class ProductModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime ProductDate { get; set; }
        public string? ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }
        public int? UserId { get; set; }
    }
}

