using Domain.Interfaces;
using MediatR;
using Services.Commands.Ideas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.Ideas
{
    public class DeleteIdeaCommandHandler : IRequestHandler<DeleteIdeaCommand, Unit> 
    {
        private readonly IIdeaRepository _ideaRepository;

        public DeleteIdeaCommandHandler(IIdeaRepository ideaRepository)
        {
            _ideaRepository = ideaRepository;
        }

        public async Task<Unit> Handle(DeleteIdeaCommand request, CancellationToken cancellationToken)
        {
            await _ideaRepository.DeleteAsync(request.Id);
            return Unit.Value; // Retorna Unit.Value como respuesta.
        }
    }
}
