using Microsoft.EntityFrameworkCore;
using NadinSoft.Data.Context;
using NadinSoft.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected NadinSoftContext _context;
        internal DbSet<T> _dbset;
        public GenericRepository(NadinSoftContext context)
        {
            _context = context;
            this._dbset = context.Set<T>();
        }


        public async Task AddAsync(T entity)
        {
           await _dbset.AddAsync(entity);
        }

        public async Task Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
             _dbset.Update(entity);
        }
    }

}
