using APBD_TASK2.Models;

namespace APBD_TASK2.Database;

public interface IDatabase
{
    public void SaveUser(User user);
    public void SaveEquipment(Equipment equipment);
    public List<Equipment> GetAllEquipment();
    public void SaveRental(Rental rental);
    public List<Rental> GetAllRentals();
    
}