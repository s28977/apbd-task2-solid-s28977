namespace APBD_TASK2.Exceptions;

public class RentalConflictException(int equipmentId, DateTime rentalDate, DateTime dueDate) : 
    Exception($"Equipment {equipmentId} is already rented for the period from {rentalDate} to {dueDate}.");