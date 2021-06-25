using System.Threading.Tasks;
using RetroCSV.Core.Entities.BoardAggregate;

namespace RetroCSV.Core.Interfaces.Persistence
{
    public interface IBoardsRepository:IAsyncRepository<Board>
    {
        Task<Board> GetBoardWithColumnsAsync(int boardId);
        
    }
}