using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetroCSV.Core.Entities.BoardAggregate;

namespace RetroCSV.Infrastructure.Persistence.Configurations
{
    public class BoardColumnConfiguration: IEntityTypeConfiguration<BoardColumn>
    {
        public void Configure(EntityTypeBuilder<BoardColumn> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
        } 
    }
}