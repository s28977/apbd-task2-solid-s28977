using APBD_TASK2.Models;

namespace APBD_TASK2.Services.Rentals;

public interface IRentalService
{
    public void RentEquipment(User user, Equipment equipment, DateTime rentalDate, DateTime dueDate);

    public void ReturnEquipment(Rental rental, DateTime returnDate);
}