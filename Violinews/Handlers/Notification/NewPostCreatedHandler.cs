using MediatR;
using Violinews.Models.Commands;

namespace Violinews.Handlers.Notification
{
    public class NewPostCreatedHandler : INotificationHandler<NewPostCreated>
    {
        public Task Handle(NewPostCreated notification, CancellationToken cancellationToken)
        {
            // Do stuff like logging
            return Task.CompletedTask;
        }
    }
}
