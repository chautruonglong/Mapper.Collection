using AutoMapper.Features;
using AutoMapper.Internal;
using Mapper.Collection.EquivalencyExpression;

namespace Mapper.Collection.Runtime
{
    public class CollectionMappingFeature : IRuntimeFeature
    {
        public CollectionMappingFeature(IEquivalentComparer equivalentComparer)
        {
            EquivalentComparer = equivalentComparer;
        }

        public IEquivalentComparer EquivalentComparer { get; }

        void IRuntimeFeature.Seal(IGlobalConfiguration configurationProvider)
        {
        }
    }
}
