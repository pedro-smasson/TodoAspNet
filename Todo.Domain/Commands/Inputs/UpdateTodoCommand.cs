using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Inputs.Contracts;

namespace Todo.Domain.Commands.Inputs
{
    public class UpdateTodoCommand : Notifiable<Notification>, ICommand
    {
        public UpdateTodoCommand() { }

        public UpdateTodoCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }

        public bool Validate()
        {
            AddNotifications
            (
                new Contract<Notification>()
                    .Requires()
                    .IsNull(Id, "Id", "Your Id cannot be null!")
                    .IsNotNullOrEmpty(Title, "Title", "Your title cannot be null nor empty!")
                    .IsLowerOrEqualsThan(Title, 5, "Please create a better description for this task!")
            );

            return IsValid;
        }
    }
}