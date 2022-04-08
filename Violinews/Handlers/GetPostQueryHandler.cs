using MediatR;
using Violinews.Models;
using Violinews.Queries;

namespace Violinews.Handlers
{
    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, Post?>
    {

        private readonly ViolinewsContext _violinewsContext;
        private readonly IMediator _mediator;

        public GetPostQueryHandler(ViolinewsContext violinewsContext, IMediator mediator)
        {
            _violinewsContext = violinewsContext;
            _mediator = mediator;
        }


        public Task<Post?> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var post = _violinewsContext.Posts.SingleOrDefault(p => p.Id == request.PostId);
            return Task.FromResult(post);
        }
    }
}
