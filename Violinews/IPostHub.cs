using Violinews.Models;

namespace Violinews
{
    public interface IPostHub
    {
        Task ReceiveMessage(Post post);
    }
}
