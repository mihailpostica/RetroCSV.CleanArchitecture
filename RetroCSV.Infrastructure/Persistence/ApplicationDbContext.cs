using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RetroCSV.Core.Entities.BoardAggregate;

namespace RetroCSV.Infrastructure.Persistence
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }
        public DbSet<Board> Boards { get; set; }
        public DbSet<BoardColumn>BoardColumns { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
    
}