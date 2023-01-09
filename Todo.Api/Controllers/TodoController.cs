using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Todo.Domain.Commands.Handlers;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command, [FromServices] CreateTodoHandler handler) 
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository) 
        {
            return repository.GetAll("Pedro");
        }
    }
}