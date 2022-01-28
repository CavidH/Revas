using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

namespace Data.Configurations
{
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {

        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.Property(p => p.Image).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Title).HasMaxLength(255).IsRequired();
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);


        }
    }
}
