using AutoMapper;
using Sol.Galaxy.Data.Entities;
using Sol.Galaxy.Domain;

namespace Sol.Galaxy.MinimalApi.Helpers
{
    public class AutomapperHelper : Profile
    {
        public AutomapperHelper()
        {

            CreateMap<Articulo, Product>()
                .ForMember(t => t.ProductId, opt => opt.MapFrom(o => o.Codigo))
                .ForMember(t => t.ProductName, opt => opt.MapFrom(o => o.Nombre))
                .ReverseMap()
                ;

        }

    }
}
