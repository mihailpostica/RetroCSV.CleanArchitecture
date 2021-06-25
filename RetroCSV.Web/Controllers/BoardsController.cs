using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetroCSV.Core.Features.Boards.Commands.AddColumn;
using RetroCSV.Core.Features.Boards.Commands.CreateBoard;
using RetroCSV.Core.Features.Boards.Queries.GetBoardWithColumns;

namespace RetroCSV_Clean_Architecture.Controllers
{
    public class BoardsController:ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateBoardCommandResponse>> Create(CreateBoardCommand command)
        {
            return Ok( await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BoardWithColumnsResponse>> GetBoardWithColumns(int id)
        {
            return Ok( await Mediator.Send(new GetBoardWithColumnsQuery{Id= id}));
        }

        [HttpPost("column")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddBoardColumn(AddColumnCommand addColumnCommand)
        {
            return Ok(await Mediator.Send(addColumnCommand));
        }
    }
}