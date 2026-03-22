using APBD_TASK2.Models;

namespace APBD_TASK2.Database;

public interface IDatabase
{
    public void SaveUser(User user);
}