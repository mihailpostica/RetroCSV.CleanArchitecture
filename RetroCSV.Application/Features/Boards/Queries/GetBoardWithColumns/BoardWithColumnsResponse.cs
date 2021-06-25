using System.Collections.Generic;
using RetroCSV.Core.Entities.BoardAggregate;
using RetroCSV.Core.Mappings;
using RetroCSV.Core.Responses;

namespace RetroCSV.Core.Features.Boards.Queries.GetBoardWithColumns
{
    public class BoardWithColumnsResponse:BaseResponse<string>,IMapFrom<Board>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string DisplayOrder { get; set; }
        public IReadOnlyCollection<BoardColumnDto> BoardColumns { get; set; }
    }
}