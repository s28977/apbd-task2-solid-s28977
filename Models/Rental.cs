namespace APBD_TASK2.Models;

public class Rental (DateTime rentalDate, DateTime dueDate, DateTime? returnDate, Equipment equipment, User user)
{
    private const double PenaltyPerDay = 0.50;
    public DateTime RentalDate { get; private set; } = rentalDate;
    public DateTime DueDate { get; private set; } = dueDate;
    public DateTime? ReturnDate { get; set; } = returnDate;
    public Equipment Equipment { get; set; } = equipment;
    public User User { get; set; } = user;
    
    public bool Overlaps(DateTime from, DateTime to)
    {
        return !(RentalDate > to || from > DueDate);
    }

    public bool IsOverdue()
    {
        return ReturnDate == null && DateTime.Now > DueDate; 
    }

    public double GetPenalty()
    {
        if (ReturnDate is null && DateTime.Now <= DueDate)
        {
            return 0;
        } 
        else if (ReturnDate is not null && ReturnDate <= DueDate)
        {
            return 0;
        }
        else if (ReturnDate is null && DateTime.Now > DueDate)
        {
            var overdueDays = Math.Ceiling((DateTime.Now - DueDate).TotalDays);
            return overdueDays * PenaltyPerDay;
        }
        else
        {
            var lateDays = Math.Ceiling((ReturnDate!.Value - DueDate).TotalDays);
            return lateDays * PenaltyPerDay;
        }
    }
}