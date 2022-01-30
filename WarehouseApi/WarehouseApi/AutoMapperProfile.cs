using AutoMapper;
using WarehouseApi.Models;

namespace WarehouseApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Car, CarBasicModel>();
        }
    }
}
