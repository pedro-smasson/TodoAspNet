using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Inputs.Contracts;

namespace Todo.Domain.Commands.Inputs
{
    public class CreateTodoCommand : Notifiable<Notification>, ICommand
    {
        public CreateTodoCommand() { }

        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get; private set; }
        public string User { get; private set; }
        public DateTime Date { get; private set; }

        public bool Validate()
        {
            AddNotifications
            (
                new Contract<Notification>()
                    .Requires()
                    .IsGreaterOrEqualsThan(Title, 5, "Please create a better description for this task!")
                    .IsNotNullOrEmpty(Title, "Title", "The title cannot be null nor empty!")
                    .IsNotNull(Date, "Date", "The date cannot be null!")
            );

            return IsValid;
        }
    }
}