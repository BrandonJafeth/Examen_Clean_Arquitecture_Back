using MediatR;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.Ideas
{

    public class GetAllIdeasQuery : IRequest<List<IdeaDto>>
    {

    }
}
