namespace APBD_TASK2.Models;

public class Student(string firstName, string lastName) : User(firstName, lastName)
{
    public override int GetMaxActiveRentals => 2;
    public override string ToString()
    {
        return $"Student #{Id}: {FirstName} {LastName}, Max active rentals: {GetMaxActiveRentals}";
    }
}