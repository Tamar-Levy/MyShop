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
            CreateMap<Order, ListUserDTO>();
            CreateMap<PostOrderDTO, Order>();
            CreateMap<LoginUserDTO, User>();
            CreateMap<PostUserDTO, User>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<User, LoginUserDTO>();

        }
    }
}
