using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ScrumDbContext _context;

        public GenericRepository(ScrumDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(T obj)
        {
            _context.Set<T>().Add(obj);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var obj = await  GetById(id);
            _context.Set<T>().Remove(obj);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<int> Update(T obj)
        {
            _context.Entry<T>(obj).State = EntityState.Modified;
            //_context.Set<T>().Update(obj);
            return await _context.SaveChangesAsync();
        }
    }
}
