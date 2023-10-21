using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoListWAuthApi.DTOs.Todo;
using TodoListWAuthApi.Entities;
using TodoListWAuthApi.Services.TodoRepository;

namespace TodoListWAuthApi.Controllers
{
    [Route("api/todo")]
    [ApiController]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly ITodoInfoRepository _todoInfoRepository;

        public TodoController(ITodoInfoRepository todoInfoRepository)
        {
            _todoInfoRepository = todoInfoRepository;
        }

        [HttpGet (Name = "GetTodos")]
        public async Task<ActionResult<IEnumerable<TodoDto>>> GetTodosAsync()
        {
            var todos = await _todoInfoRepository.GetTodosAsync();
            var todosToGet = todos.Select(T => new TodoDto()
            {
                Name = T.Name,
                Description = T.Description,
                CompletionState = T.CompletionState
            }).ToList();
            return todosToGet;
        }
        
        [HttpGet("{id}", Name = "GetTodo")]
        public async Task<ActionResult<TodoDto>> GetTodoAsync(int id)
        {
            Todo todo = await _todoInfoRepository.GetTodoAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            var todoToGet = new TodoDto
            {
                Name = todo.Name,
                Description = todo.Description,
                CompletionState = todo.CompletionState
            };
            return Ok(todoToGet);
        }

        [HttpPost]
        public async Task<ActionResult<TodoCreateUpdateDto>> PostTodoAsync(TodoCreateUpdateDto recievedtodo)
        {
            var todo = new Todo
            {
                Name = recievedtodo.Name,
                Description = recievedtodo.Description,
                CompletionState = recievedtodo.CompletionState,
                UserId = recievedtodo.UserId
            };
            int createdTodoId = await _todoInfoRepository.CreateTodoAsync(todo);
            return CreatedAtAction("GetTodo", new {id = createdTodoId}, recievedtodo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTodoAsync(int id,TodoCreateUpdateDto recievedtodo)
        {
            bool todoExists = await _todoInfoRepository.TodoExistAsync(id);
            if (!todoExists)
            {
                return NotFound();
            }
            var updatedTodo = new Todo
            {
                Id = id,
                Name = recievedtodo.Name,
                Description = recievedtodo.Description,
                CompletionState = recievedtodo.CompletionState,
                UserId = recievedtodo.UserId
            };
            await _todoInfoRepository.UpdateTodoAsync(updatedTodo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodoAsync(int id)
        {
            Todo todoToDelete = await _todoInfoRepository.GetTodoAsync(id);
            if (todoToDelete == null)
            {
                return NotFound();
            }
            await _todoInfoRepository.DeleteTodoAsync(todoToDelete);
            return NoContent();
        }
    }
}
