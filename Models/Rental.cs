namespace APBD_TASK2.Models;

public class Rental (DateTime rentalDate, DateTime dueDate, DateTime? returnDate, Equipment equipment, User user)
{
    private const double PenaltyPerDay = 0.50;
    public DateTime RentalDate { get; private set; } = rentalDate;
    public DateTime DueDate { get; private set; } = dueDate;
    public DateTime? ReturnDate { get; set; } = returnDate;
    public Equipment Equipment { get; set; } = equipment;
    public User User { get; set; } = user;
    
    public double Penalty
    {
        get
        {
            DateTime endDate = ReturnDate ?? DateTime.Now;
            if (endDate <= DueDate)
            {
                return 0;
            }
            double lateDays = Math.Ceiling((endDate - DueDate).TotalDays);
            return lateDays * PenaltyPerDay;
        }
    }
    
    public bool Overlaps(DateTime from, DateTime to)
    {
        return !(RentalDate > to || from > DueDate);
    }

    public bool IsOverdue()
    {
        return ReturnDate == null && DateTime.Now > DueDate; 
    }
}