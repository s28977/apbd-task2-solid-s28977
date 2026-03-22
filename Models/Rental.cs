namespace APBD_TASK2.Models;

public class Rental (DateTime rentalDate, DateTime dueDate, DateTime? returnDate, Equipment equipment, User user)
{
    public DateTime RentalDate { get; private set; } = rentalDate;
    public DateTime DueDate { get; private set; } = dueDate;
    public DateTime? ReturnDate { get; private set; } = returnDate;
    public Equipment Equipment { get; set; } = equipment;
    public User User { get; set; } = user;
    
    public bool Overlaps(DateTime from, DateTime to)
    {
        return !(RentalDate > to || from > DueDate);
    }

    public bool IsDelayed()
    {
        return ReturnDate == null && DueDate > DateTime.Now; 
    }
}