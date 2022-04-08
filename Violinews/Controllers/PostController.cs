using MediatR;
using Microsoft.AspNetCore.Mvc;
using Violinews.Commands;
using Violinews.Queries;

namespace Violinews.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {


        private readonly ILogger<PostController> _logger;
        private readonly IMediator _mediator;

        public PostController(ILogger<PostController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{postId}")]
        public async Task<ActionResult> GetPost(Guid postId)
        {
            var queryPost = new GetPostQuery() { PostId = postId };
            var response = await _mediator.Send(queryPost);
            if(response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePost([FromBody] AddNewPostCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
  
    }
}