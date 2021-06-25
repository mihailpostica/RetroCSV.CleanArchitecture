using RetroCSV.Core.Responses;

namespace RetroCSV.Core.Features.Boards.Commands.CreateBoard
{
    public class CreateBoardCommandResponse:BaseResponse<string>
    {
        public int Id { get; set; }
    }
}