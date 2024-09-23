using Domain.Interfaces;
using MediatR;
using Services.DTOs;
using Services.Queries.Ideas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Handlers.Ideas
{
    public class GetAllIdeasQueryHandler : IRequestHandler<GetAllIdeasQuery, List<IdeaDto>>
    {
        private readonly IIdeaRepository _ideaRepository;

        public GetAllIdeasQueryHandler(IIdeaRepository ideaRepository)
        {
            _ideaRepository = ideaRepository;
        }

        public async Task<List<IdeaDto>> Handle(GetAllIdeasQuery request, CancellationToken cancellationToken)
        {
            var ideas = await _ideaRepository.GetAllAsync();

            // Mapear las entidades a DTOs (puedes usar AutoMapper para simplificar)
            var ideaDtos = ideas.Select(idea => new IdeaDto
            {
                Id = idea.Id,
                Title = idea.Title,
                Description = idea.Description,
                CreatedBy = idea.CreatedBy,
                VotesCount = idea.VotesCount,
                CreatedDate = idea.CreatedDate
            }).ToList();

            return ideaDtos;
        }
    }
}
