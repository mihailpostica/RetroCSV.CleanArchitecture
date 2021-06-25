using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RetroCSV.Core.Interfaces.Persistence;

namespace RetroCSV.Core.Features.Boards.Queries.GetBoardWithColumns
{
    public class GetBoardWithColumnsQuery:IRequest<BoardWithColumnsResponse>
    {
        public int Id { get; set; }
    }

    public class GetBoardWithColumnsQueryHandler : IRequestHandler<GetBoardWithColumnsQuery, BoardWithColumnsResponse>
    {
        private readonly IBoardsRepository _boardsRepository;
        private readonly IMapper _mapper;

        public GetBoardWithColumnsQueryHandler(IBoardsRepository boardsRepository, IMapper mapper)
        {
            _boardsRepository = boardsRepository;
            _mapper = mapper;
        }

        public async Task<BoardWithColumnsResponse> Handle(GetBoardWithColumnsQuery request, CancellationToken cancellationToken)
        {
            var board = await _boardsRepository.GetBoardWithColumnsAsync(request.Id); 
            var addBoardResponse=_mapper.Map<BoardWithColumnsResponse>(board);
            addBoardResponse.Success = true;
            return addBoardResponse;
        }
    }
}