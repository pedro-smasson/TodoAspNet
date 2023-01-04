using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands.Inputs;

namespace Todo.Domain.Tests.Commands.Inputs
{
    [TestClass]
    public class CreateTodoCommandTest
    {
        [DataTestMethod]
        [DataRow("T")]
        [DataRow("Te")]
        [DataRow("Tes")]
        [DataRow("Test")]
        public void Should_return_false_when_todo_name_contains_less_than_5_letters(string todoName) 
        {
            //Arrange
            var sut = new CreateTodoCommand(todoName, "Pedro", DateTime.Now);

            //Act
            sut.Validate();

            //Assert
            Assert.IsFalse(sut.IsValid);
        }

        [TestMethod]
        public void Should_return_false_when_todo_name_is_null() 
        {
            //Arrange
            var sut = new CreateTodoCommand(null, "Pedro", DateTime.Now);

            //Act
            sut.Validate();

            //Assert
            Assert.IsFalse(sut.IsValid);
        }

        [TestMethod]
        public void Should_return_false_when_todo_date_is_null() 
        {
            //Arrange
            var sut = new CreateTodoCommand("Do the laundry", "Pedro", null);

            //Act
            sut.Validate();

            //Assert
            Assert.IsFalse(sut.IsValid);
        }

        [TestMethod]
        public void Should_return_true_when_command_is_valid()
        {
            //Arrange
            var sut = new CreateTodoCommand("Do the laundry", "Pedro", DateTime.Now);

            //Act
            sut.Validate();

            //Assert
            Assert.IsTrue(sut.IsValid);
        }
    }
}