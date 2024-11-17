using Entities;

namespace Services
{
    public interface IUserServices
    {
        User LoginUser(string userName, string password);
        User RegisterUser(User user);
        User UpdateUser(int id, User user);
        int UserPassword(string password);
    }
}