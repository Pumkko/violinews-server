using MediatR;
using Violinews.Models;
using Violinews.Queries;

namespace Violinews.Handlers
{
    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, IEnumerable<Post>>
    {

        private readonly ViolinewsContext _violinewsContext;
        private readonly IMediator _mediator;

        public GetPostQueryHandler(ViolinewsContext violinewsContext, IMediator mediator)
        {
            _violinewsContext = violinewsContext;
            _mediator = mediator;
        }


        public Task<IEnumerable<Post>> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var post = _violinewsContext.Posts.AsEnumerable();
            return Task.FromResult(post);
        }
    }
}
