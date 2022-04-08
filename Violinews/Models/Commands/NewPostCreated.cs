using MediatR;

namespace Violinews.Models.Commands
{
    public class NewPostCreated : INotification
    {

        public Post NewPost { get; }

        public NewPostCreated(Post newPost)
        {
            NewPost = newPost;
        }
    }
}
