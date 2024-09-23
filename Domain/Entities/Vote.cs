using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vote
    {
        public int Id { get; set; }                
        public int IdeaId { get; set; }            
        public string UserName { get; set; }        
        public DateTime VotedDate { get; set; }     

        // Relación con la entidad Idea.
        public Idea Idea { get; set; }
    }
}
