using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IPropertyMappingValue
    {
        IEnumerable<string> DestinationProperties { get; }
    }
}