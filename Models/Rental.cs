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

    public bool IsCurrentlyDelayed()
    {
        return ReturnDate == null && DueDate > DateTime.Now; 
    }

    public double GetPenalty()
    {
        switch (ReturnDate)
        {
            case null when DueDate <= DateTime.Now:
                return 0;
            case null when DueDate > DateTime.Now:
            {
                var overdueDays = Math.Ceiling((DateTime.Now - DueDate).TotalDays);
                return overdueDays*PenaltyPerDay;
            }
            default:
            {
                var overdueDays = Math.Ceiling((ReturnDate!.Value - DueDate).TotalDays);
                return overdueDays*PenaltyPerDay;
            }
        }
    }
}