using APBD_TASK2.Database;
using APBD_TASK2.Models;

namespace APBD_TASK2.Services.Equipments;

public class EquipmentService(IDatabase database) : IEquipmentService
{
    private IDatabase Database { get; } = database;
    public void AddEquipment(Equipment equipment)
    {
        Database.SaveEquipment(equipment);
    }
}