using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.Ideas
{
    public class CreateIdeaCommand : IRequest<int> 
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
    }
}
