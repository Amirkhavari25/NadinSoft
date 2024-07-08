using Microsoft.EntityFrameworkCore;
using NadinSoft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Data.Context
{
    public class NadinSoftContext : DbContext
    {
        public NadinSoftContext(DbContextOptions<NadinSoftContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Products>()
                .HasIndex(u => u.ManufactureEmail)
                .IsUnique();
            builder.Entity<Products>()
                .HasIndex(c => c.ProductDate)
                .IsUnique();
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
