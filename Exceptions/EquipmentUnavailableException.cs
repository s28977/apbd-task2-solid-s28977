namespace APBD_TASK2.Exceptions;

public class EquipmentUnavailableException(int equipmentId) : Exception($"Equipment with id {equipmentId} is not available.");