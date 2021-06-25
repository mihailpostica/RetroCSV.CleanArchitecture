using System.ComponentModel.DataAnnotations;
using RetroCSV.SharedKernel;

namespace RetroCSV.Core.Entities.BoardAggregate
{
    public class BoardColumn:BaseEntity
    {
        public string Description { get; set; }    
        public int BoardId { get; set; }

    }
}