using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.ObjectModel;
using Violinews.Commands;
using Violinews.Models;
using Violinews.Queries;

namespace Violinews.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IMediator _mediator;

        private readonly IHubContext<PostHub, IPostHub> _postHub;

        public PostController(ILogger<PostController> logger, IMediator mediator, IHubContext<PostHub, IPostHub> postHub)
        {
            _logger = logger;
            _mediator = mediator;
            _postHub = postHub;
        }

        [HttpGet]
        public async Task<ActionResult> GetPost()
        {
            var queryPost = new GetPostQuery();
            var response = await _mediator.Send(queryPost);
            if (!response.Any())
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePost([FromBody] AddNewPostCommand command)
        {
            var response = await _mediator.Send(command);

            await _postHub.Clients.All.ReceiveMessage(response);
            return Ok(response);
        }

        [HttpDelete("{postId}")]
        public async Task<ActionResult> DeletePost(Guid postId)
        {
            await _mediator.Send(new DeletePostCommand(postId));
            return NoContent();
        }
    }
}