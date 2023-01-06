using System;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo) { }

        public TodoItem GetTodoById(Guid? id, string user) { return new TodoItem("Lorem Ipsum", DateTime.Now, "Pedro"); }

        public void Update(TodoItem todo) { }
    }
}