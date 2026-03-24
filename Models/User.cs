namespace APBD_TASK2.Models;

public abstract class User(string firstName, string lastName)
{
    private static int _id = 1;

    public int Id { get; } = _id++;
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
    public abstract int GetMaxActiveRentals { get; }
}