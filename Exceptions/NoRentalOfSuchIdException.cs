namespace APBD_TASK2.Exceptions;

public class NoRentalOfSuchIdException(int rentalId) : Exception($"There is no rental with id {rentalId}.");