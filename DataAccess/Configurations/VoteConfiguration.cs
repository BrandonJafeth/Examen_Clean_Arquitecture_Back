using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities; // Asegúrate de que el namespace es correcto.

namespace ExamenPR.DataAccess.Configurations
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.HasOne(v => v.Idea)
                   .WithMany(i => i.Votes)
                   .HasForeignKey(v => v.IdeaId);
           
        }
    }
}
