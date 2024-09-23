using Domain.Entities;
using ExamenPR.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

// El DataAcces solo lo use para el contexto 
namespace DataAccess.MyDbContext
{
    public class MyContext : DbContext
    {
        // Constructor del DbContext que recibe las opciones de configuración.
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Vote> Votes { get; set; }

  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Configuraciones de base de datos
            modelBuilder.ApplyConfiguration(new IdeaConfiguration());
            modelBuilder.ApplyConfiguration(new VoteConfiguration());
        }
    }
}
