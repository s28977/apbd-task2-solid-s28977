using APBD_TASK2.Database;
using APBD_TASK2.Interfaces;
using APBD_TASK2.Models;

namespace APBD_TASK2.Services;

public class UserService(IDatabase database) : IUserService
{
    private IDatabase Database { get; } = database;
    public void AddUser(User user)
    {
        Database.SaveUser(user);
    }

    public List<User> GetAllUsers()
    {
        return Database.GetAllUsers();
    }

    public User? GetUserById(int userId)
    {
        return GetAllUsers().FirstOrDefault(user => user.Id == userId);
    }
}