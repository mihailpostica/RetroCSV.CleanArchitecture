using RetroCSV.Core.Responses;

namespace RetroCSV.Core.Features.Boards.Commands.AddColumn
{
    public class AddColumnCommandResponse:BaseResponse<string>
    {
        public int ColumnId { get; set; }
    }
    
}