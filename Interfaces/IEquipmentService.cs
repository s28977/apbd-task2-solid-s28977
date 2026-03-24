using APBD_TASK2.Models;

namespace APBD_TASK2.Interfaces;

public interface IEquipmentService
{
    public void AddEquipment(Equipment equipment);
    public List<Equipment> GetAllEquipment();
    public Equipment? GetEquipmentById(int equipmentId);
    public List<Equipment> GetAvailableEquipment();
    public void MarkAsUnavailable(int equipmentId);
}