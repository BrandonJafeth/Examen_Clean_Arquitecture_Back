using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Ideas;
using Services.Queries.Ideas;
using Services.DTOs;
using Microsoft.AspNetCore.SignalR;
using ExamenPR.Hubs;

namespace ExamenPR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdeasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHubContext<IdeasHub> _hubContext;

        public IdeasController(IMediator mediator, IHubContext<IdeasHub> hubContext)
        {
            _mediator = mediator;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateIdea(CreateIdeaCommand command)
        {
            var result = await _mediator.Send(command);
            await _hubContext.Clients.All.SendAsync("ReceiveNewIdea", $"New idea created with ID {result}");
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<IdeaDto>>> GetAllIdeas()
        {
            var result = await _mediator.Send(new GetAllIdeasQuery());
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIdea(int id)
        {
            await _mediator.Send(new DeleteIdeaCommand { Id = id });

            
            await _hubContext.Clients.All.SendAsync("ReceiveIdeaDeleted", $"Idea with ID {id} was deleted.");

            return NoContent(); 
        }

    }
}
