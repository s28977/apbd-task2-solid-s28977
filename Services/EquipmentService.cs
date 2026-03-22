using APBD_TASK2.Database;
using APBD_TASK2.Interfaces;
using APBD_TASK2.Models;

namespace APBD_TASK2.Services;

public class EquipmentService(IDatabase database) : IEquipmentService
{
    private IDatabase Database { get; } = database;
    public void AddEquipment(Equipment equipment)
    {
        Database.SaveEquipment(equipment);
    }

    public List<Equipment> GetAllEquipment()
    {
        return Database.GetAllEquipment();
    }

    public List<Equipment> GetAvailableEquipment()
    {
        return Database.GetAllEquipment().Where(e => e.IsAvailable).ToList();
    }

    public void MarkAsUnavailable(Equipment equipment)
    {
        equipment.IsAvailable = false;
    }
}