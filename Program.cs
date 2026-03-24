using APBD_TASK2.Database;
using APBD_TASK2.Exceptions;
using APBD_TASK2.Interfaces;
using APBD_TASK2.Models;
using APBD_TASK2.Services;

IDatabase db = Singleton.Instance;
IEquipmentService equipmentService = new EquipmentService(db);
IUserService userService = new UserService(db);
IRentalService rentalService = new RentalService(db, userService, equipmentService);

//11.Adding several equipment items of different types.

Laptop laptop1 = new Laptop("ThinkPad X1 Carbon", "Lenovo", "Intel Core i7-1365U", 16);
Laptop laptop2 = new Laptop("MacBook Pro 14", "Apple", "M3 Pro", 18);

Projector projector1 = new Projector("EB-X49", "Epson", 3600, 16000);
Projector projector2 = new Projector("VPL-EX575", "Sony", 4200, 20000);

Camera camera1 = new Camera("EOS 250D", "Canon", 1.8, 6400);
Camera camera2 = new Camera("Alpha A6400", "Sony", 2.8, 32000);

equipmentService.AddEquipment(laptop1);
equipmentService.AddEquipment(laptop2);
equipmentService.AddEquipment(projector1);
equipmentService.AddEquipment(projector2);
equipmentService.AddEquipment(camera1);
equipmentService.AddEquipment(camera2);

foreach (var equipment in equipmentService.GetAllEquipment())
{
    Console.WriteLine(equipment);
}

//12.Adding several users of different types.

Student student1 = new Student("Jan", "Kowalski");
Student student2 = new Student("Anna", "Nowak");

Employee employee1 = new Employee("Piotr", "Wiśniewski");
Employee employee2 = new Employee("Maria", "Zielińska");

userService.AddUser(student1);
userService.AddUser(student2);
userService.AddUser(employee1);
userService.AddUser(employee2);

foreach (var user in userService.GetAllUsers())
{
    Console.WriteLine(user);
}

DateTime rentalDate = DateTime.Today;
DateTime dueDate = DateTime.Today.AddDays(7);

//13.A correct rental operation.

rentalService.RentEquipment(1, 1, rentalDate, dueDate);

Console.WriteLine(rentalService.GetRentalById(1));

//14.An attempted invalid operation, for example renting unavailable equipment or exceeding a user limit.

equipmentService.MarkAsUnavailable(2);

try
{
    rentalService.RentEquipment(2,2, rentalDate, dueDate);
}
catch (EquipmentUnavailableException e)
{
    Console.WriteLine(e);
}

//15.A return completed on time.

rentalService.ReturnEquipment(1, dueDate.AddDays(-1));

Console.WriteLine(rentalService.GetRentalById(1));

//16.A delayed return that leads to a penalty.

rentalService.RentEquipment(3,3,rentalDate,dueDate);
rentalService.ReturnEquipment(2, dueDate.AddDays(+2));

Console.WriteLine(rentalService.GetRentalById(2));

//17.Displaying a final report of the system state.