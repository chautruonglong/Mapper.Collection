using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using Mapper.Collection.EquivalencyExpression;
using Xunit;

namespace AutoMapper.Collection;

public class MapCollectionTests
{
    private readonly IMapper _mapper;

    public MapCollectionTests()
    {
        _mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddCollectionMappers();
            cfg.CreateMap<ThingA, ThingB>();
            cfg.CreateMap<Data, Data>()
                .ForMember(src => src.Name, opt => opt.Condition(_ => false))
                .EqualityComparison((src, dst) => src.Id == dst.Id);
        }));
    }

    [Fact]
    public void Test()
    {
        
        var src = new ThingA
        {
            Datas = new List<Data>
            {
                new()
                {
                    Id = 0,
                    Name = "A0"
                },
                new()
                {
                    Id = 1,
                    Name = "A1"
                }
            }
        };
        
        var dst = new ThingB
        {
            Datas = new List<Data>
            {
                new()
                {
                    Id = 0,
                    Name = "B0"
                },
                new()
                {
                    Id = 2,
                    Name = "B2"
                }
            }
        };

        _mapper.Map(src, dst).ShouldBeEquivalentTo(new
        {
            Datas = new List<Data>
            {
                new()
                {
                    Id = 0,
                    Name = "B0"
                },
                new()
                {
                    Id = 1,
                    Name = null
                }
            }
        });
    }

    public class Data
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
    
    public class ThingA
    {
        public IEnumerable<Data> Datas { get; set; }
    }
    
    public class ThingB
    {
        public IEnumerable<Data> Datas { get; set; }
    }
}