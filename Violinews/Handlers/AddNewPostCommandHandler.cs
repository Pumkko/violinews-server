using MediatR;
using Violinews.Commands;
using Violinews.Models;
using Violinews.Models.Commands;

namespace Violinews.Handlers
{
    public class AddNewPostCommandHandler : IRequestHandler<AddNewPostCommand, Post>
    {
        private readonly ViolinewsContext _violinewsContext;
        private readonly IMediator _mediator;

        public AddNewPostCommandHandler(ViolinewsContext violinewsContext, IMediator mediator)
        {
            _violinewsContext = violinewsContext;
            _mediator = mediator;
        }

        public async Task<Post> Handle(AddNewPostCommand request, CancellationToken cancellationToken)
        {
            await _violinewsContext.Database.EnsureCreatedAsync();

            var post = new Post(request.Id, request.Title, request.Content, DateTime.UtcNow);

            _violinewsContext.Posts.Add(post);
            await _violinewsContext.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new NewPostCreated(post), cancellationToken);

            return post;

        }
    }
}
