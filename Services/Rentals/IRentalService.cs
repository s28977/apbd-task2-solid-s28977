using APBD_TASK2.Models;

namespace APBD_TASK2.Services.Rentals;

public interface IRentalService
{
    public Rental CreateRental(User user, Equipment equipment, DateTime rentalDate, DateTime dueDate);
}