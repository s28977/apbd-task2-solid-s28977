namespace APBD_TASK2.Exceptions;

public class NoEquipmentOfSuchIdException(int equipmentId) : Exception($"There is no equipment with id {equipmentId}.");