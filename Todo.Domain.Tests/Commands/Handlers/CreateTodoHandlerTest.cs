using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands.Handlers;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.Commands.Handlers
{
    [TestClass]
    public class CreateTodoHandlerTest
    {
        private FakeTodoRepository _repository = new FakeTodoRepository();

        [TestMethod]
        public void Should_return_true_when_handler_create_todo_successfully() 
        {
            //Arrange
            var sut = new CreateTodoHandler(_repository);
            var command = new CreateTodoCommand("Do the laundry", "Pedro", DateTime.Now);
            
            //Act
            sut.Handle(command);

            //Assert
            Assert.IsTrue(sut.IsValid);
        }

        [TestMethod]
        //TODO: create dataTestMethod w/ dataRows and test all the scenarios where command fails when validating the constructor
        public void Generic_command_result_should_return_false_when_todo_name_contains_less_than_5_letters()
        {
            //Arrange
            var sut = new CreateTodoHandler(_repository);
            var command = new CreateTodoCommand("Test", "Pedro", DateTime.Now);

            //Act
            var result = (GenericCommandResult)sut.Handle(command);

            //Assert
            Assert.IsFalse(result.Success);
        }
    }
}