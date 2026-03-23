using APBD_TASK2.Models;

namespace APBD_TASK2.Interfaces;

public interface IUserService
{
    public void AddUser(User user);
    public List<User> GetAllUsers();
    public User? GetUserById(int userId);
}