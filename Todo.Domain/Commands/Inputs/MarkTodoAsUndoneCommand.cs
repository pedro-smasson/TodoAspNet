using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Inputs.Contracts;

namespace Todo.Domain.Commands.Inputs
{
    public class MarkTodoAsUndoneCommand : Notifiable<Notification>, ICommand
    {
        public MarkTodoAsUndoneCommand() { }

        public MarkTodoAsUndoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; private set; }
        public string User { get; private set; }

        public bool Validate()
        {
            AddNotifications
            (
                new Contract<Notification>()
                    .Requires()
                    .IsNotNullOrEmpty(User, "User", "The user cannot be null nor empty!")
                    .IsGreaterOrEqualsThan(User, 5, "The user cannot have less than 5 characters!")
            );

            return IsValid;
        }
    }
}