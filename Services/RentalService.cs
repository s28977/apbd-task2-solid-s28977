using APBD_TASK2.Database;
using APBD_TASK2.Exceptions;
using APBD_TASK2.Interfaces;
using APBD_TASK2.Models;

namespace APBD_TASK2.Services;

public class RentalService(IDatabase database, IUserService userService, IEquipmentService equipmentService) : IRentalService
{
    private IDatabase Database { get; } = database;
    private IUserService UserService { get; } = userService;
    private IEquipmentService EquipmentService { get; } = equipmentService;
    
    public void RentEquipment(int userId, int equipmentId, DateTime rentalDate, DateTime dueDate)
    {
        var user = UserService.GetUserById(userId);
        if (user == null)
        {
            throw new NoUserOfSuchIdException(userId);
        }
        var equipment = EquipmentService.GetEquipmentById(equipmentId);
        if (equipment == null)
        {
            throw new NoEquipmentOfSuchIdException(userId);
        }
        if (!equipment.IsAvailable)
        {
            throw new EquipmentUnavailableException(equipment.Id);
        }

        if (SomeoneIsAlreadyRentingThisEquipment(equipment, rentalDate, dueDate))
        {
            throw new RentalConflictException(equipment.Id, rentalDate, dueDate);
        }
        if (GetActiveRentals(userId).Count >= user.GetMaxActiveRentals)
        {
            throw new TooManyRentalsException(user.Id);
        }
        var newRental = new Rental(rentalDate,  dueDate, null,  equipment, user);
        Database.SaveRental(newRental);
    }

    public void ReturnEquipment(int rentalId, DateTime returnDate)
    {
        var rental = GetRentalById(rentalId);
        if (rental == null)
        {
            throw new NoRentalOfSuchIdException(rentalId);
        }
        rental.ReturnDate = returnDate;
    }

    public List<Rental> GetRentals()
    {
        return Database.GetAllRentals();
    }

    public Rental? GetRentalById(int rentalId)
    {
        return GetRentals().FirstOrDefault(rental => rental.Id == rentalId);
    }

    public List<Rental> GetActiveRentals(int userId)
    {
        var user = UserService.GetUserById(userId);
        if (user == null)
        {
            throw new NoUserOfSuchIdException(userId);
        }
        return GetRentals().Where(rental =>
            rental.ReturnDate == null
            && rental.User == user).ToList();
    }

    public List<Rental> GetAllOverdueRentals()
    {
        return GetRentals().Where(rental =>
            rental.IsOverdue()).ToList();
    }


    private bool SomeoneIsAlreadyRentingThisEquipment(Equipment equipment, DateTime rentalDate, DateTime dueDate)
    {
        return GetRentals()
            .Any(rental => rental.Equipment == equipment && (rental.Overlaps(rentalDate, dueDate) || rental.IsOverdue()));
    }
}