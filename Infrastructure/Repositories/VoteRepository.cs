using DataAccess.MyDbContext;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class VoteRepository : GenericRepository<Vote>, IVoteRepository
    {
        public VoteRepository(MyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Vote>> GetByIdeaIdAsync(int ideaId)
        {
            return await _dbSet.Where(v => v.IdeaId == ideaId).ToListAsync();
        }
    }
}