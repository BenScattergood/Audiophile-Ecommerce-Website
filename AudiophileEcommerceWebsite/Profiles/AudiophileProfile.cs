
using AutoMapper;

namespace AudiophileEcommerceWebsite.Profiles
{
    public class AudiophileProfile : Profile
    {
        public AudiophileProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.Id, o =>
                    o.MapFrom(p => p.ProductId))
                .ForMember(m => m.Name, o =>
                    o.MapFrom(p => p.ProductName));

            CreateMap<RelatedData, RelatedDataViewModel>();

            CreateMap<ShoppingBasketItem, ShoppingBasketItemViewModel>();

            CreateMap<Order, OrderViewModel>()
                .ReverseMap();
        }
    }
}
