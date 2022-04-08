using MediatR;

namespace Violinews.Commands
{
    public class DeletePostCommand : IRequest
    {
        public Guid PostId { get; }

        public DeletePostCommand(Guid postId)
        {
            PostId = postId;
        }
    }
}
