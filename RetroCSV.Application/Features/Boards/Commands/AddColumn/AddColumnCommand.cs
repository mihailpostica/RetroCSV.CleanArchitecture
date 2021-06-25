using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RetroCSV.Core.Entities.BoardAggregate;
using RetroCSV.Core.Interfaces.Persistence;
using RetroCSV.Core.Mappings;

namespace RetroCSV.Core.Features.Boards.Commands.AddColumn
{   
    //the request class
    public class AddColumnCommand:IRequest<AddColumnCommandResponse>,IMapFrom<BoardColumn>
    {
        public int BoardId { get; set; }
        public string Description { get; set; }

    }
    //the handler class. 
    public class AddColumnCommandHandler : IRequestHandler<AddColumnCommand, AddColumnCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoardsRepository _boardsRepository;
        

        public AddColumnCommandHandler(IMapper mapper, IBoardsRepository boardsRepository)
        {
            _mapper = mapper;
            _boardsRepository = boardsRepository;
        }

        public async Task<AddColumnCommandResponse> Handle(AddColumnCommand request, CancellationToken cancellationToken)
        {
            var boardColumn = _mapper.Map<BoardColumn>(request);
            var board = await _boardsRepository.GetBoardWithColumnsAsync(boardColumn.BoardId);
            
            board.AddColumn(boardColumn);
            
            await  _boardsRepository.UpdateAsync(board);
            return new AddColumnCommandResponse
            {
                Success = true,
                ColumnId = board.BoardColumns.Last().Id,
                Message = "Column was added successfully"
            };
        }
    }
}