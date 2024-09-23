using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.Votes
{
    public class VoteForIdeaCommand : IRequest<Unit> 
    {
        public int IdeaId { get; set; }          
        public string UserName { get; set; }     
    }
}
