using System.Collections.Generic;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class PropertyMapping<TSource, TDestination> : IPropertyMapping
    {
        public Dictionary<string, IPropertyMappingValue> _mappingDictionary { get; set; }

        public PropertyMapping(Dictionary<string, IPropertyMappingValue> mappingDictionary)
        {
            _mappingDictionary = mappingDictionary;
        } 
    }
}