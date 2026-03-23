namespace APBD_TASK2.Exceptions;

public class NoUserOfSuchIdException(int userId) : Exception($"There is no user with id {userId}.");