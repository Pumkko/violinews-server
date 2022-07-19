using MediatR;
using Violinews.Models;

namespace Violinews.Commands
{
    public class AddNewPostCommand : IRequest<Post>
    {
        public Guid Id { get; set; }

        public string Title { get; init; } = default!;

        public string Content { get; init; } = default!;
    }
}
