using Repositories;
using Entities;
using Zxcvbn;
namespace Services;

public class UserServices : IUserServices
{
    IUserRepository _UserRepository;

    public UserServices(IUserRepository userRepository)
    {
        _UserRepository = userRepository;
    }

    public User UpdateUser(int id, User user)
    {
        var resualt = UserPassword(user.Password);
        if (resualt < 2)
        {
            User tmpUser = new();
            tmpUser.FirstName = "weak password";
            return tmpUser;
        }
        return _UserRepository.UpdateUser(id, user);
    }
    public int UserPassword(string password)
    {
        var result = Zxcvbn.Core.EvaluatePassword(password);
        return result.Score;
    }

    public User LoginUser(string userName, string password)
    {
        return _UserRepository.LoginUser(userName, password);
    }

    public User RegisterUser(User user)
    {
       var resualt= UserPassword(user.Password);
        if (resualt < 2)
        {
            User tmpUser = new();
            tmpUser.FirstName = "weak password";
            return tmpUser;
        }
         return _UserRepository.Register(user);
    }
    
}
