using APBD_TASK2.Database;
using APBD_TASK2.Exceptions;
using APBD_TASK2.Models;

namespace APBD_TASK2.Services.Rentals;

public class RentalService(IDatabase database) : IRentalService
{
    private IDatabase Database { get; } = database;
    public void RentEquipment(User user, Equipment equipment, DateTime rentalDate, DateTime dueDate)
    {
        if (!equipment.IsAvailable)
        {
            throw new EquipmentUnavailableException(equipment.Id);
        }

        if (SomeoneIsAlreadyRentingThisEquipment(equipment, rentalDate, dueDate))
        {
            throw new RentalConflictException(equipment.Id, rentalDate, dueDate);
        }
        if (ActiveUserRentals(user) > user.GetMaxActiveRentals)
        {
            throw new TooManyRentalsException(user.Id);
        }
        var newRental = new Rental(rentalDate,  dueDate, null,  equipment, user);
        Database.SaveRental(newRental);
    }

    public void ReturnEquipment(Rental rental, DateTime returnDate)
    {
        rental.ReturnDate = returnDate;
    }


    private bool SomeoneIsAlreadyRentingThisEquipment(Equipment equipment, DateTime rentalDate, DateTime dueDate)
    {
        return Database
            .GetAllRentals()
            .Any(rental => rental.Equipment == equipment && (rental.Overlaps(rentalDate, dueDate) || rental.IsCurrentlyDelayed()));
}

    private int ActiveUserRentals(User user)
    {
        return Database.GetAllRentals().Count(rental =>
            rental.ReturnDate == null
            && rental.User == user);
    }
}