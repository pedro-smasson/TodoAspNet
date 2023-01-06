using Flunt.Notifications;
using Todo.Domain.Commands.Handlers.Contracts;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Commands.Inputs.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Commands.Handlers
{
    public class UpdateTodoHandler : Notifiable<Notification>, IHandler<UpdateTodoCommand>
    {
        private readonly ITodoRepository _todoRepository;

        public UpdateTodoHandler(ITodoRepository todoRepository)
            => _todoRepository = todoRepository;

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();

            if (!command.IsValid)
                return new GenericCommandResult(false, "Oops! Something went wrong...", command.Notifications);

            var todo = _todoRepository.GetTodoById(command.Id, command.User);
            
            todo.UpdateTitle(command.Title);

            _todoRepository.Update(todo);

            return new GenericCommandResult(true, "Todo updated successfully!", null);
        }
    }
}