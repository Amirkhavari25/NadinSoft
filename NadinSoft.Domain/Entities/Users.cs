using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Domain.Entities
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public string? FullName { get; set; }
        public ICollection<Products> Products{ get; set; } = new List<Products>();

        public Users(int userId,string name)
        {
            UserId = userId;
            Name = name;
        }
    }
}
