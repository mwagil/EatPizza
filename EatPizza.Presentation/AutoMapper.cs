using AutoMapper;
using EatPizza.Application.Models;
using EatPizza.Domain.Entities;

namespace EatPizza
{
#pragma warning disable 1591
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Pizza, PizzaViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<OrderDelivery, OrderDeliveryViewModel>().ReverseMap();
            CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
            CreateMap<OrderItemSplit, OrderItemSplitViewModel>().ReverseMap();
        }
    }
}
