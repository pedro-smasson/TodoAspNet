using Flunt.Notifications;
using Todo.Domain.Commands.Handlers.Contracts;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Commands.Inputs.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Commands.Handlers
{
    public class MarkTodoAsUndoneHandler : Notifiable<Notification>, IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _todoRepository;

        public MarkTodoAsUndoneHandler(ITodoRepository todoRepository)
            => _todoRepository = todoRepository;

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            return new GenericCommandResult(true, "Todo updated successfully!", null);
        }
    }
}