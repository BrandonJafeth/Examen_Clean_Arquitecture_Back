using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVoteRepository : IGenericRepository<Vote>
    {
        Task<IEnumerable<Vote>> GetByIdeaIdAsync(int ideaId);
     
    }
}
