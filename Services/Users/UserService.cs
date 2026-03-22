using APBD_TASK2.Database;
using APBD_TASK2.Models;

namespace APBD_TASK2.Services.Users;

public class UserService(IDatabase database) : IUserService
{
    private IDatabase Database { get; } = database;
    public void AddUser(User user)
    {
        Database.SaveUser(user);
    }
}