using System;

namespace RetroCSV.Core.Exceptions
{
    public class DuplicateColumnException:ApplicationException
    {
        public DuplicateColumnException(string message):base(message)
        {
            
        }
        
    }
}