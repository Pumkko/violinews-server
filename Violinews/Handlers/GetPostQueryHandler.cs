using MediatR;
using Microsoft.EntityFrameworkCore;
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


        public async Task<IEnumerable<Post>> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            await _violinewsContext.Database.EnsureCreatedAsync();
            var post = _violinewsContext.Posts.AsEnumerable();
            return post;
        }
    }
}
