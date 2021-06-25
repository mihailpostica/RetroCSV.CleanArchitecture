using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetroCSV.Core.Entities.BoardAggregate;

namespace RetroCSV.Infrastructure.Persistence.Configurations
{
    public class BoardConfiguration:IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.HasMany(b => b.BoardColumns);
        }
    }
}