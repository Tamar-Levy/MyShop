using System.Runtime.InteropServices;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace Repositories;
public class UsersRepository : IUsersRepository 
{
    MyShop0331Context _context;

    public UsersRepository(MyShop0331Context context)
    {
        _context = context;
    }

    // GetById
    public async Task<User> GetById(int id)
    {
        return await _context.Users.Include(u=>u.Orders).FirstOrDefaultAsync(user => user.UserId == id);
    }

    //Login
    public async Task<User> LoginUser(string email, string password)
    {
        User userFound= await _context.Users.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
        if (userFound != null)//return userFound, if it's null- will return null.
            return userFound;
        return null;//
    }

    //Register
    public async Task<User> Register(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    // Update
    public async Task<User> UpdateUser(int id, User userToUpdate)
    {
        userToUpdate.UserId = id;
        _context.Users.Update(userToUpdate);
        await _context.SaveChangesAsync();
        return userToUpdate;
    }

}
