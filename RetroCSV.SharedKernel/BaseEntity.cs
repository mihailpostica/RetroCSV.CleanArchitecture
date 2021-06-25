using System.Collections.Generic;

namespace RetroCSV.SharedKernel
{

    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}