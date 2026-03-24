namespace APBD_TASK2.Models;

public class Rental (DateTime rentalDate, DateTime dueDate, DateTime? returnDate, Equipment equipment, User user)
{
    private const double PenaltyPerDay = 0.50;
    private static int _id = 1;
    public int Id { get; } = _id++;
    public DateTime RentalDate { get; } = rentalDate;
    public DateTime DueDate { get; } = dueDate;
    public DateTime? ReturnDate { get; set; } = returnDate;
    public Equipment Equipment { get; } = equipment;
    public User User { get; } = user;
    
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
    
    public override string ToString()
    {
        string returnInfo = ReturnDate.HasValue
            ? ReturnDate.Value.ToShortDateString()
            : "Not returned";

        return $"Rental #{Id}: {User.FirstName} {User.LastName} rented {Equipment.Brand} {Equipment.Name} " +
               $"from {RentalDate.ToShortDateString()} to {DueDate.ToShortDateString()}, " +
               $"Return: {returnInfo}, Penalty: {Penalty:F2}";
    }
}