using Entities.Models;
using Entities.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Repository<T> : IRepository<ToDoListModel> where T : class
    {
        private readonly ToDoDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(ToDoDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(ToDoListModel entity)
        {
             await _context.ToDos.AddAsync(entity);
             await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           var todo = await _context.ToDos.FindAsync(id);
            if (todo != null)
            {
                _context.ToDos.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ToDoListModel>> GetAllAsync()
        {
            return await _context.ToDos.ToListAsync();
        }

        public async Task<ToDoListModel> GetIdByAsync(int id)
        {
            return await _context.ToDos.FindAsync(id);
        }

        public async Task UpdateAsync(ToDoListModel entity)
        {
             _context.ToDos.Update(entity);
            _context.SaveChanges();
        }
    }
}
