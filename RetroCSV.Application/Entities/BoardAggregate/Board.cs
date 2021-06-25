using System;
using System.Collections.Generic;
using System.Linq;
using RetroCSV.Core.Exceptions;
using RetroCSV.SharedKernel;
using RetroCSV.SharedKernel.Interfaces;

namespace RetroCSV.Core.Entities.BoardAggregate
{
    public class Board : BaseEntity ,IAggregateRoot
    {
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public int UserId { get; set; }
        
        private readonly List<BoardColumn> _boardColumns=new List<BoardColumn>();

        public IEnumerable<BoardColumn> BoardColumns => _boardColumns.AsReadOnly();
        
        //public Team Team { get; set; } this will eventually belong to a team

        public void AddColumn(BoardColumn boardColumn)
        {
            _ = boardColumn ?? throw new ApplicationException("The boardColumn object can not be null");

            if (_boardColumns.Any(c => c.Description.Equals(boardColumn.Description,StringComparison.OrdinalIgnoreCase)))
                throw new DuplicateColumnException("A column with such name already exists");
            
            _boardColumns.Add(boardColumn);
            
        }
    }
}