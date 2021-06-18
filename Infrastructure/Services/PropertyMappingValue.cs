using System.Collections.Generic;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class PropertyMappingValue: IPropertyMappingValue
    {   
        // 目標屬性清單的字串列表
        public IEnumerable<string> DestinationProperties { get; private set; }

        public PropertyMappingValue(IEnumerable<string> destinationProperties)
        {
            DestinationProperties = destinationProperties;
        }
    }
}