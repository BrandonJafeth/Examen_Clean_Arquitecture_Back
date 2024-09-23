using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Services.Commands.Ideas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Handlers.Ideas
{
    public class CreateIdeaCommandHandler : IRequestHandler<CreateIdeaCommand, int>
    {
        private readonly IIdeaRepository _ideaRepository;

        public CreateIdeaCommandHandler(IIdeaRepository ideaRepository)
        {
            _ideaRepository = ideaRepository;
        }

        public async Task<int> Handle(CreateIdeaCommand request, CancellationToken cancellationToken)
        {
            var newIdea = new Idea
            { 
                Title = request.Title,
                Description = request.Description,
                CreatedBy = request.CreatedBy,
                CreatedDate = DateTime.UtcNow,
                VotesCount = 0
            };

            await _ideaRepository.AddAsync(newIdea);
            return newIdea.Id;
        }
    }
}
