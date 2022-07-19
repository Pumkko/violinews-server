using Microsoft.AspNetCore.SignalR;
using Violinews.Models;

namespace Violinews
{
    public class PostHub : Hub<IPostHub>
    {
    }
}
