using AutoMapper;
using DTO;
using Entities;

namespace MyShop
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Product,ProductDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
