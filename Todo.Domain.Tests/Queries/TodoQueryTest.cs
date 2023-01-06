using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.Queries
{
    [TestClass]
    public class TodoQueryTest
    {
        private readonly List<TodoItem> _items;

        public TodoQueryTest()
        {
            _items = new List<TodoItem>
            {
                new TodoItem("Task 1", DateTime.Now, "Pedro"),
                new TodoItem("Task 2", DateTime.Now.AddDays(1), "Pedro2"),
                new TodoItem("Task 3", DateTime.Now.AddMonths(1), "Pedro"),
                new TodoItem("Task 4", DateTime.Now.AddYears(1), "Pedro")
            };
        }

        private void AssignTrueOrFalseToTodos() 
        {
            _items[0].MarkAsDone();
            _items[1].MarkAsDone();
            _items[2].MarkAsUndone();
            _items[3].MarkAsDone();
        }

        [TestMethod]
        public void Should_return_all_todos_that_have_pedro_as_username() 
        {
            //Arrange & Act
            var sut = _items.AsQueryable().Where(TodoQuery.GetAll("Pedro"));

            //Assert
            Assert.AreEqual(3, sut.Count());
        }

        [TestMethod]
        public void Should_return_all_todos_that_are_done_based_on_chosen_username() 
        {
            //Arrange & Act
            AssignTrueOrFalseToTodos();

            var sutPedro = _items.AsQueryable().Where(TodoQuery.GetAllDone("Pedro"));
            var sutPedro2 = _items.AsQueryable().Where(TodoQuery.GetAllDone("Pedro2"));

            //Assert
            Assert.AreEqual(2, sutPedro.Count());
            Assert.AreEqual(1, sutPedro2.Count());
        }

        [TestMethod]
        public void Should_return_all_todos_that_are_undone_based_on_chosen_username()
        {
            //Arrange & Act
            AssignTrueOrFalseToTodos();

            var sut = _items.AsQueryable().Where(TodoQuery.GetAllUndone("Pedro"));

            //Assert
            Assert.AreEqual(1, sut.Count());
        }
    }
}