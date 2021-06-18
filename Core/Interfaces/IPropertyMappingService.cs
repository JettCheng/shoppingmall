using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IPropertyMappingService
    {
        Dictionary<string, IPropertyMappingValue> GetPropertyMapping<TSource, TDestination>();
    }
}