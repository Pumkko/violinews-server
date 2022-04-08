using MediatR;
using Violinews.Models;

namespace Violinews.Queries
{
    public class GetPostQuery : IRequest<IEnumerable<Post>>
    {
    }
}
