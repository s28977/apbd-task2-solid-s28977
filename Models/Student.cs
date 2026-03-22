namespace APBD_TASK2.Models;

public class Student(string firstName, string lastName) : User(firstName, lastName)
{
    public override int GetMaxActiveRentals => 2;
}