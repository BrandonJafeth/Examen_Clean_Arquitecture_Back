using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Services.Commands.Votes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Handlers.Votes
{
   
    public class VoteForIdeaCommandHandler : IRequestHandler<VoteForIdeaCommand, Unit>
    {
        private readonly IVoteRepository _voteRepository;
        private readonly IIdeaRepository _ideaRepository;

        public VoteForIdeaCommandHandler(IVoteRepository voteRepository, IIdeaRepository ideaRepository)
        {
            _voteRepository = voteRepository;
            _ideaRepository = ideaRepository;
        }

        public async Task<Unit> Handle(VoteForIdeaCommand request, CancellationToken cancellationToken)
        {
        
            var idea = await _ideaRepository.GetByIdAsync(request.IdeaId);
            if (idea == null)
            {
                throw new KeyNotFoundException($"La idea con ID {request.IdeaId} no existe.");
            }

          
            var vote = new Vote
            {
                IdeaId = request.IdeaId,
                UserName = request.UserName,
                VotedDate = DateTime.UtcNow
            };

           
            await _voteRepository.AddAsync(vote);

       
            idea.VotesCount += 1;
            await _ideaRepository.UpdateAsync(idea);

            return Unit.Value;
        }
    }
}
