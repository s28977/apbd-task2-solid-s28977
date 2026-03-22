namespace APBD_TASK2.Exceptions;

public class TooManyRentalsException(int userId) : Exception($"There is too many active rentals for user {userId}.");