﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contract
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetIdByAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity); 
        Task DeleteAsync(int id);

    }
}
