using Entities.Models;
using Entities.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoService _todoService;

        public ToDoListController(IToDoService todoService)
        {
            _todoService = todoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsynnc()
        {
            var todos = await _todoService.GetAllToDoAsync();
            return Ok(todos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            
            var todos = await _todoService.GetToDoByIdAsync(id);
            if (todos == null)
            {
                return NotFound($"Todo item with Id = {id} was not found.");
            }
            return Ok(todos);
        }
        [HttpPost]
        public async Task<IActionResult> AddTodoAsync([FromBody]ToDoListDTO todoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toDo = new ToDoListModel
            {
                Title = todoDTO.Title,
                Description = todoDTO.Description,
                IsCompleted = todoDTO.IsCompleted,
                DueDate = todoDTO.DueDate,
            };
            await _todoService.AddToDoAsync(toDo);
            
            return Ok(toDo);
                
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoAsync(int id)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
            await _todoService.DeleteToDoAsync(id);
            return Ok();

            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoAsync(int id, [FromBody]ToDoListDTO todoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existiongToDo = await _todoService.GetToDoByIdAsync(id);
            if (existiongToDo == null)
                return NotFound();
            existiongToDo.Title = todoDTO.Title;
            existiongToDo.Description = todoDTO.Description;
            existiongToDo.IsCompleted = todoDTO.IsCompleted;
            existiongToDo.DueDate = todoDTO.DueDate;

            await _todoService.UpdateToDoAsync(existiongToDo);
            return Ok(existiongToDo);
        }
        
    }
}
