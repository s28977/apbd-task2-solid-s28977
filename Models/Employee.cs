namespace APBD_TASK2.Models;

public class Employee(string firstName, string lastName) : User(firstName, lastName)
{
    public override int GetMaxActiveRentals => 5;
    public override string ToString()
    {
        return $"Employee #{Id}: {FirstName} {LastName}, Max active rentals: {GetMaxActiveRentals}";
    }
}