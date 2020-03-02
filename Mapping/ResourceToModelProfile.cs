using AutoMapper;
using robotistan.Domain.Models;
using robotistan.Domain.Models.Queries;
using robotistan.Resources;

namespace robotistan.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();

            CreateMap<SaveProductResource, Product>();

            CreateMap<SaveSepetResource, Sepet>();

            CreateMap<SaveSiparisResource, Siparis>();

            CreateMap<SaveSliderResource, Slider>();

            CreateMap<SaveUserResource, User>();


            CreateMap<ProductsQueryResource, ProductsQuery>();
            CreateMap<SepetQueryResource, SepetQuery>();
            CreateMap<SiparisQueryResource, SiparisQuery>();
        }
    }
}