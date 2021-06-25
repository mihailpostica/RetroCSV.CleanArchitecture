using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RetroCSV.Core.Entities.BoardAggregate;
using RetroCSV.Core.Interfaces.Persistence;
using RetroCSV.Core.Mappings;

namespace RetroCSV.Core.Features.Boards.Commands.CreateBoard
{
    public class CreateBoardCommand:IRequest<CreateBoardCommandResponse>,IMapFrom<Board>
    {
        public string Name { get; set; }

        public int Order { get; set; }

        public int UserId { get; set; }

        public int DisplayOrder { get; set; }
        
        // public int TeamId { get; set; }
        
    }

    public class CreateBoardCommandHandler : IRequestHandler<CreateBoardCommand, CreateBoardCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoardsRepository _boardsRepository;

        public CreateBoardCommandHandler(IMapper mapper, IBoardsRepository boardsRepository)
        {
            _mapper = mapper;
            _boardsRepository = boardsRepository;
        }

        public async  Task<CreateBoardCommandResponse> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            var board = _mapper.Map<Board>(request);
            board=await _boardsRepository.AddAsync(board);
            return new CreateBoardCommandResponse
            {
                Id = board.Id,
                Message = "The board was successfully created",
                Success = true
            };
        }
    }
}