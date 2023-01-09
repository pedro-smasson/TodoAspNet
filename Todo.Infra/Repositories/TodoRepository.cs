using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;
using Todo.Infra.Contexts;

namespace Todo.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _todoContext;

        public TodoRepository(TodoContext todoContext)
            => _todoContext = todoContext;

        public void Create(TodoItem todo)
        {
            _todoContext.Todos.Add(todo);
            _todoContext.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            return _todoContext.Todos
                .AsNoTracking()
                .Where(TodoQuery
                .GetAll(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllByPeriod(string user, bool done, DateTime date)
        {
            return _todoContext.Todos
                .AsNoTracking()
                .Where(TodoQuery
                .GetByPeriod(user, done, date))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _todoContext.Todos
                .AsNoTracking()
                .Where(TodoQuery
                .GetAllDone(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            return _todoContext.Todos
                .AsNoTracking()
                .Where(TodoQuery
                .GetAllUndone(user))
                .OrderBy(x => x.Date);
        }

        public TodoItem GetTodoById(Guid? id, string user)
        {
            return _todoContext.Todos
                .AsNoTracking()
                .Where(TodoQuery
                .GetTodoById(id, user))
                .OrderBy(x => x.Date)
                .FirstOrDefault();
        }

        public void Update(TodoItem todo)
        {
            _todoContext.Entry(todo).State = EntityState.Modified;
            _todoContext.SaveChanges();
        }
    }
}