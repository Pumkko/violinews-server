using MediatR;

namespace Violinews.Commands
{
    public class AddNewPostCommand : IRequest<Guid>
    {
        public string Title { get; init; } = default!;

        public string Content { get; init; } = default!;
    }
}
