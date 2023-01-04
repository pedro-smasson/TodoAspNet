using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands.Inputs;

namespace Todo.Domain.Tests.Commands.Inputs
{
    [TestClass]
    public class UpdateTodoCommandTest
    {
        [TestMethod]
        public void Should_return_false_when_todo_id_is_null()
        {
            //Arrange
            var sut = new UpdateTodoCommand(null, "Do the laundry", "Pedro");

            //Act
            sut.Validate();

            //Assert
            Assert.IsFalse(sut.IsValid);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void Should_return_false_when_todo_title_is_null_or_empty(string todoTitle)
        {
            //Arrange
            var sut = new UpdateTodoCommand(Guid.NewGuid(), todoTitle, "Pedro");

            //Act
            sut.Validate();

            //Assert
            Assert.IsFalse(sut.IsValid);
        }

        [DataTestMethod]
        [DataRow("T")]
        [DataRow("Te")]
        [DataRow("Tes")]
        [DataRow("Test")]
        public void Should_return_false_when_todo_title_contains_less_than_5_letters(string todoTitle)
        {
            //Arrange
            var sut = new UpdateTodoCommand(Guid.NewGuid(), todoTitle, "Pedro");

            //Act
            sut.Validate();

            //Assert
            Assert.IsFalse(sut.IsValid);
        }

        [TestMethod]
        public void Should_return_true_when_command_is_valid() 
        {
            //Arrange
            var sut = new UpdateTodoCommand(Guid.NewGuid(), "Do the laundry", "Pedro");

            //Act
            sut.Validate();

            //Assert
            Assert.IsTrue(sut.IsValid);
        }
    }
}