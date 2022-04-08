using MediatR;
using Violinews.Models;

namespace Violinews.Queries
{
    public class GetPostQuery : IRequest<Post?>
    {
        public Guid PostId { get; init; }
    }
}
