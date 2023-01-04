using Flunt.Notifications;
using Todo.Domain.Commands.Handlers.Contracts;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Commands.Inputs.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Commands.Handlers
{
    public class CreateTodoHandler : Notifiable<Notification>, IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _todoRepository;

        public CreateTodoHandler(ITodoRepository todoRepository)
            => _todoRepository = todoRepository;

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();

            if (!command.IsValid)
                return new GenericCommandResult(false, "Oops! Something went wrong...", command.Notifications);

            var todo = new TodoItem(command.Title, command.Date, command.User);

            _todoRepository.Create(todo);

            return new GenericCommandResult(true, "Todo created successfully!", null);
        }
    }
}
