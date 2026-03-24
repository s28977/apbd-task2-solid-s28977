using APBD_TASK2.Interfaces;

namespace APBD_TASK2.Services;

public class ConsoleReportGenerator(IUserService userService, IEquipmentService equipmentService, IRentalService rentalService) : IReportGenerator
{
    private IUserService UserService { get; } = userService;
    private IEquipmentService EquipmentService { get; } = equipmentService;
    private IRentalService RentalService { get; } = rentalService;

    public void GenerateReport()
    {
        Console.WriteLine("Report");
        Console.WriteLine();
        Console.WriteLine("Users and their rentals:");
        foreach (var user in UserService.GetAllUsers())
        {
            Console.WriteLine(user);
            Console.WriteLine("Current user rentals:");
            foreach (var rental in RentalService.GetActiveRentals(user.Id))
            {
                Console.WriteLine(rental);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("Equipment:");
        foreach (var equipment in EquipmentService.GetAllEquipment())
        {
            Console.WriteLine(equipment);
        }
        
        Console.WriteLine();
        Console.WriteLine("Available Equipment:");
        foreach (var equipment in EquipmentService.GetAvailableEquipment())
        {
            Console.WriteLine(equipment);
        }

        Console.WriteLine();
        Console.WriteLine("Rentals:");
        foreach (var rental in RentalService.GetRentals())
        {
            Console.WriteLine(rental);
        }
        
        Console.WriteLine();
        Console.WriteLine("Overdue rentals:");
        foreach (var rental in RentalService.GetAllOverdueRentals())
        {
            Console.WriteLine(rental);
        }
    }
}