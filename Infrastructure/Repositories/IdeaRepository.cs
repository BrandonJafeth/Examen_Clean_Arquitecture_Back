using DataAccess.MyDbContext;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class IdeaRepository : GenericRepository<Idea>, IIdeaRepository
    {
        public IdeaRepository(MyContext context) : base(context)
        {
        }

      
    }
}
