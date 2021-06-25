using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetroCSV.Core.Entities.BoardAggregate;
using RetroCSV.Core.Exceptions;
using RetroCSV.Core.Interfaces.Persistence;

namespace RetroCSV.Infrastructure.Persistence.Repositories
{
    
    public class BoardsRepository:BaseRepository<Board>,IBoardsRepository
    {
        public BoardsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Board> GetBoardWithColumnsAsync(int boardId)
        {
            var board= await DbContext.Boards.Include(b=>b.BoardColumns).FirstOrDefaultAsync(b=>b.Id==boardId);
            _ = board ?? throw new NotFoundException("Found the requested board was not.");
           return board;
        }
    }
}