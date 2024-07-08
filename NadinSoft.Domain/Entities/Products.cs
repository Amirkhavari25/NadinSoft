using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Domain.Entities
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public DateTime ProductDate { get; set; }
        public string? ManufacturePhone { get; set; }
        public MailAddress ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }
        [ForeignKey(nameof(UserId))]
        public Users? User { get; set; }
        public int? UserId { get; set; }
    }
}
