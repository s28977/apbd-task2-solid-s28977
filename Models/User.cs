namespace APBD_TASK2.Models;

public abstract class User(string firstName, string lastName)
{
    private static int _id = 1;

    public int Id { get; set; } = _id++;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public abstract int GetMaxActiveRentals { get; }
    
    public override string ToString()
    {
        return $"{GetType().Name} #{Id}: {FirstName} {LastName}, Max active rentals: {GetMaxActiveRentals}";
    }
}