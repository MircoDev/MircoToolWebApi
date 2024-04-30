using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mirco.MircosTool.Data.Infrastructure.Repositories;
using Mirco.MircosTool.Models.Dto;
using Mirco.MircosTool.Models.Entities.todo;
using Mirco.MircosTool.Models.Extensions;
using MircoToolWebApi.Data;
using MircoToolWebApi.Entities;

namespace MircoToolWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private readonly ITodoRepository _todoRepository;

        public ToDoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDo>>> GetAllToDos() 
        {
            var todos = await _todoRepository.AsQueryable().ToListAsync();

            return Ok(todos);
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDo>>> GetAllToDoToComplete()
        {
            var todos = await _todoRepository
                .AsQueryable()
                .Where(t=> !t.IsCompleted).ToListAsync();

            return Ok(todos);
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDo>>> GetAllCompletedToDo()
        {
            var todos = await _todoRepository
                .AsQueryable()
                .Where(t => t.IsCompleted).ToListAsync();

            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDo>> GetTodoByKey(int id)
        {
            var todo = await _todoRepository.ReadAsync(id);

            if(todo is null)
                return NotFound("ToDo non found");

            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<List<ToDo>>> AddTodo([FromBody] TodoDto tododto)
        {
            ToDo newtodo = tododto.ToEntity();

            ToDo? todo = await _todoRepository.CreateAsync(newtodo);

            if (todo is null)
                return NotFound("ToDo not added");

            int saveAsyncResult = await _todoRepository.SaveAsync();

            if (saveAsyncResult == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(todo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ToDo>> CompleteTodo(int id)
        {
            var todo = await _todoRepository.ReadAsync(id);

            if (todo is null)
                return NotFound("No Todo found with that key");

            todo.IsCompleted = true;
            todo.DateUpdated = DateTime.Now;

            int saveAsyncResult =  await _todoRepository.SaveAsync();

            if(saveAsyncResult == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(todo);
        }

    }
}
