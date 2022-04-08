using MediatR;
using Violinews.Commands;
using Violinews.Models;
using Violinews.Models.Commands;

namespace Violinews.Handlers
{
    public class AddNewPostCommandHandler : IRequestHandler<AddNewPostCommand, Guid>
    {
        private readonly ViolinewsContext _violinewsContext;
        private readonly IMediator _mediator;

        public AddNewPostCommandHandler(ViolinewsContext violinewsContext, IMediator mediator)
        {
            _violinewsContext = violinewsContext;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(AddNewPostCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var post = new Post(id, request.Title, request.Content, DateTime.UtcNow);

            _violinewsContext.Posts.Add(post);
            await _violinewsContext.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new NewPostCreated(post), cancellationToken);

            return id;

        }
    }
}
