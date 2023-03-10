using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Commands.Handlers;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    //[Authorize]
    public class TodoController : ControllerBase
    {
        // you can use this property when SQL Server is the main database of the system, otherwise it will not work (replace all d "Pedro" w/ this)
        //public string FindUser { get => User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value; }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command, [FromServices] CreateTodoHandler handler)
            => (GenericCommandResult)handler.Handle(command);

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
            => repository.GetAll("Pedro");

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository)
            => repository.GetAllDone("Pedro");

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone([FromServices] ITodoRepository repository)
            => repository.GetAllUndone("Pedro");

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday([FromServices] ITodoRepository repository)
            => repository.GetAllByPeriod("Pedro", true, DateTime.Today);

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForToday([FromServices] ITodoRepository repository)
            => repository.GetAllByPeriod("Pedro", false, DateTime.Today);

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices] ITodoRepository repository)
            => repository.GetAllByPeriod("Pedro", true, DateTime.Today.AddDays(1));

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForTomorrow([FromServices] ITodoRepository repository)
            => repository.GetAllByPeriod("Pedro", false, DateTime.Today.AddDays(1));

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update([FromBody] UpdateTodoCommand command, [FromServices] UpdateTodoHandler handler)
            => (GenericCommandResult)handler.Handle(command);
    }
}