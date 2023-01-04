using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.Entities
{
    [TestClass]
    public class TodoItemTest
    {
        [TestMethod]
        public void Todo_title_must_be_equal() 
        {
            //Arrange
            var sut = new TodoItem("Do the laundry", DateTime.Now, "Pedro");

            //Act
            sut.UpdateTitle("Play basketball");

            //Assert
            Assert.AreEqual(sut.Title, "Play basketball");
        }
    }
}