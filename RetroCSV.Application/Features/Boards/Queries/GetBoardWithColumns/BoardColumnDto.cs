using RetroCSV.Core.Entities.BoardAggregate;
using RetroCSV.Core.Mappings;
using RetroCSV.Core.Responses;

namespace RetroCSV.Core.Features.Boards.Queries.GetBoardWithColumns
{
    public class BoardColumnDto:IMapFrom<BoardColumn>
    {
        public string Description { get; set; }
        public int Id { get; set; }
    }
}