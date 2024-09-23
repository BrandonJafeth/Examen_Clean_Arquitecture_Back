﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities; // Asegúrate de que el namespace es correcto.

namespace ExamenPR.DataAccess.Configurations
{
    public class IdeaConfiguration : IEntityTypeConfiguration<Idea>
    {
        public void Configure(EntityTypeBuilder<Idea> builder)
        {
           
            builder.Property(i => i.Title)
                   .IsRequired()              
                   .HasMaxLength(100);       

 
        }
    }
}
