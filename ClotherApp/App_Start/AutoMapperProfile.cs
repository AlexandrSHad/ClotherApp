using AutoMapper;
using ClothApp.Domain;
using ClothApp.Models;

namespace ClotherApp.App_Start
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cloth, ClothIndexViewModel>();
            CreateMap<ClothCreateForm, Cloth>();
        }
    }
}