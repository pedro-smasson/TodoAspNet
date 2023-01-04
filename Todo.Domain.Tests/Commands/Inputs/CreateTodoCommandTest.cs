using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands.Inputs;

namespace Todo.Domain.Tests.Commands.Inputs
{
    [TestClass]
    public class CreateTodoCommandTest
    {
        [DataTestMethod]
        [DataRow("T", "Pedro")]
        [DataRow("Te", "Pedro")]
        [DataRow("Tes", "Pedro")]
        [DataRow("Test", "Pedro")]
        [DataRow("Tests", "Pedro")]
        public void Should_return_false_when_todo_name_contains_less_than_6_letters(string todoName, string userName) 
        {
            //Arrange
            var sut = new CreateTodoCommand(todoName, userName, DateTime.Now);

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
    }
}