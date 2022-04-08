using MediatR;
using Violinews.Commands;
using Violinews.Models;

namespace Violinews.Handlers
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly ViolinewsContext _violinewsContext;

        public DeletePostCommandHandler(ViolinewsContext violinewsContext)
        {
            _violinewsContext = violinewsContext;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var postToDelete = new Post(request.PostId, string.Empty, string.Empty, DateTime.Now);
            _violinewsContext.Posts.Attach(postToDelete);
            _violinewsContext.Posts.Remove(postToDelete);

            await _violinewsContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
