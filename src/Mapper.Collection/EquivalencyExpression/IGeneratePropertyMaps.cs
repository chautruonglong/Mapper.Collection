using System.Collections.Generic;
using AutoMapper;

namespace Mapper.Collection.EquivalencyExpression
{
    public interface IGeneratePropertyMaps
    {
        IEnumerable<PropertyMap> GeneratePropertyMaps(TypeMap typeMap);
    }
}