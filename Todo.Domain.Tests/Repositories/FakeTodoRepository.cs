using System;
using System.Collections.Generic;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo) { }

        public IEnumerable<TodoItem> GetAll(string user)
            { yield return new TodoItem("Lorem Ipsum", DateTime.Now, "Pedro"); }

        public IEnumerable<TodoItem> GetAllByPeriod(string user, bool done, DateTime date)
            { yield return new TodoItem("Lorem Ipsum", DateTime.Now, "Pedro"); }

        public IEnumerable<TodoItem> GetAllDone(string user)
            { yield return new TodoItem("Lorem Ipsum", DateTime.Now, "Pedro"); }

        public IEnumerable<TodoItem> GetAllUndone(string user)
            { yield return new TodoItem("Lorem Ipsum", DateTime.Now, "Pedro"); }

        public TodoItem GetTodoById(Guid? id, string user) { return new TodoItem("Lorem Ipsum", DateTime.Now, "Pedro"); }

        public void Update(TodoItem todo) { }
    }
}