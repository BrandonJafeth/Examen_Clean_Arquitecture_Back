using ExamenPR.Hubs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR; // Importar SignalR.
using Services.Commands.Votes;
using Services.DTOs;


namespace ExamenPR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHubContext<IdeasHub> _hubContext; 

        public VotesController(IMediator mediator, IHubContext<IdeasHub> hubContext)
        {
            _mediator = mediator;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<ActionResult> VoteForIdea(VoteForIdeaCommand command)
        {
            await _mediator.Send(command);

            await _hubContext.Clients.All.SendAsync("ReceiveVoteNotification", $"New vote registered for Idea ID {command.IdeaId}");

            return Ok();
        }
    }
}
