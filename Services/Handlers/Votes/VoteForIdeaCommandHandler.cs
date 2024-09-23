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
    // Handler para gestionar la lógica del comando de votar por una idea.
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
            // Verificar si la idea existe.
            var idea = await _ideaRepository.GetByIdAsync(request.IdeaId);
            if (idea == null)
            {
                throw new KeyNotFoundException($"La idea con ID {request.IdeaId} no existe.");
            }

            // Crear un nuevo voto.
            var vote = new Vote
            {
                IdeaId = request.IdeaId,
                UserName = request.UserName,
                VotedDate = DateTime.UtcNow
            };

            // Agregar el voto al repositorio.
            await _voteRepository.AddAsync(vote);

            // Incrementar el contador de votos en la idea.
            idea.VotesCount += 1;
            await _ideaRepository.UpdateAsync(idea);

            return Unit.Value;
        }
    }
}