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
            Assert.AreEqual("Play basketball", sut.Title);
        }

        [TestMethod]
        public void Todo_status_must_be_done()
        {
            //Arrange
            var sut = new TodoItem("Do the laundry", DateTime.Now, "Pedro");

            //Act
            sut.MarkAsDone();

            //Assert
            Assert.AreEqual(true, sut.Done);
        }

        [TestMethod]
        public void Todo_status_must_be_on_going() 
        {
            //Arrange
            var sut = new TodoItem("Do the laundry", DateTime.Now, "Pedro");

            //Act
            sut.MarkAsOnGoing();

            //Assert
            Assert.AreEqual(false, sut.Done);
        }
    }
}