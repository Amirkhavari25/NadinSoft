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
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        private NadinSoftContext _context;
        public ProductRepository(NadinSoftContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Products?> GetProductForEdit(int id)
        {
           return await _context.Products.FirstOrDefaultAsync(d=>d.Id == id);
        }


    }
}
