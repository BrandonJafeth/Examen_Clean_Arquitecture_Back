using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Idea
    {
        public int Id { get; set; }                 
        public string Title { get; set; }          
        public string Description { get; set; }     
        public string CreatedBy { get; set; }       // Nombre del que creo la idea de proyecto
        public DateTime CreatedDate { get; set; }  
        public int VotesCount { get; set; }         

        // Relación con la entidad Vote (una Idea puede tener muchos Votes).
        public List<Vote> Votes { get; set; }
    }

}
