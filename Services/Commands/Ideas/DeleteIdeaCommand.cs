using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.Ideas
{
    public class DeleteIdeaCommand : IRequest<Unit> 
    {
        public int Id { get; set; }
    }
}
