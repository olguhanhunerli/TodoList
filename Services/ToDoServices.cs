using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contract;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ToDoServices : IToDoService
    {
        private readonly IRepository<ToDoListModel> _todoRepository;

        public ToDoServices(IRepository<ToDoListModel> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task AddToDoAsync(ToDoListModel toDo)
        {
            await _todoRepository.AddAsync(toDo);
        }

        public async Task DeleteToDoAsync(int id)
        {
            await _todoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ToDoListModel>> GetAllToDoAsync()
        {
            return await _todoRepository.GetAllAsync();
        }

        public async Task<ToDoListModel> GetToDoByIdAsync(int id)
        {
            return await _todoRepository.GetIdByAsync(id);
        }

        public async Task UpdateToDoAsync(ToDoListModel toDo)
        {
            await _todoRepository.UpdateAsync(toDo);
        }
    }
}
