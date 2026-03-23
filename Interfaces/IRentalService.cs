using APBD_TASK2.Models;

namespace APBD_TASK2.Interfaces;

public interface IRentalService
{
    public void RentEquipment(int userId, int equipmentId, DateTime rentalDate, DateTime dueDate);

    public void ReturnEquipment(int rentalId, DateTime returnDate);
    public Rental? GetRentalById(int rentalId);

    public List<Rental> GetActiveRentals(int userId);
    public List<Rental> GetAllOverdueRentals();
}