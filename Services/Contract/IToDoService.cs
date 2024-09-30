using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoListModel>> GetAllToDoAsync();

        Task<ToDoListModel> GetToDoByIdAsync(int id);
        Task AddToDoAsync(ToDoListModel toDo);
        Task UpdateToDoAsync(ToDoListModel toDo);
        Task DeleteToDoAsync(int id);
    }
}
