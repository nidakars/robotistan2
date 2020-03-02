using AutoMapper;
using robotistan.Domain.Models;
using robotistan.Domain.Models.Queries;
using robotistan.Extensions;
using robotistan.Resources;

namespace robotistan.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();

            CreateMap<Product, ProductResource>();

            CreateMap<Sepet, SepetResource>();

            CreateMap<Siparis, SiparisResource>();

            CreateMap<Slider, SliderResource>();

            CreateMap<User, UserResource>();

            CreateMap<QueryResult<Product>, QueryResultResource<ProductResource>>();
            CreateMap<QueryResult<Sepet>, QueryResultResource<SepetResource>>();
            CreateMap<QueryResult<Siparis>, QueryResultResource<SiparisResource>>();
        }
    }
}