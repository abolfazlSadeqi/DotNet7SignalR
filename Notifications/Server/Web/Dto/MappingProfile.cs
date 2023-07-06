using AutoMapper;
using Model;

namespace API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Add as many of these lines as you need to map your objects
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();

    }
}

