# APBD Task 2
## 1. Design Decisions
The `Models` folder contains classes that represent the main entities from the problem domain. These classes are designed primarily as data holders and include only minimal logic. Most of the application logic is placed in the `Services` folder. For example, `EquipmentService` handles operations related to equipment, such as adding items to the database or updating their availability, `UserService` manages user-related operations, and `RentalService` contains the core business logic related to renting and returning equipment.

This separation was intentional. Model classes describe what the system works with, while service classes define what the system does. As a result, the code is easier to understand, test, and extend.

The design also follows the **Single Responsibility Principle**. Each model represents one concept from the domain, and each service focuses on one specific area of behavior. For example, `RentalService` is responsible for rental-related processes, while reporting is delegated to a separate report generator.

The **Open/Closed Principle** can be seen in the inheritance hierarchy where `Student` and `Employee` extend the `User` class. This makes it possible to introduce new types of users in the future without modifying the base `User` class itself. For this reason, I chose separate classes instead of using an enum, because subclasses allow different user types to have their own properties and behavior if needed later.

A similar idea applies to the `Equipment` hierarchy. Both `User` and `Equipment` are abstract base classes, while concrete classes such as `Student`, `Employee`, `Laptop`, `Camera`, or `Projector` represent actual objects used by the system. This allows the database and service layer to work with these objects through the common abstractions of `User` and `Equipment` rather than through each concrete type separately. In practice, this simplifies the architecture, because services can store, retrieve, and process all user types as `User` objects and all equipment types as `Equipment` objects. At the same time, the design still preserves the ability to introduce specialized properties and behavior in subclasses when needed. This is a practical use of polymorphism and makes the system easier to extend without increasing complexity in the service and database layers.

Another important decision was to define service interfaces in the `Interfaces` folder and make the concrete services implement them. This makes the architecture more flexible, because the system depends on abstractions rather than concrete implementations. For instance, the reporting mechanism can easily be replaced with another implementation, such as a generator that writes reports to a file instead of displaying them in the console.

This also reflects the **Dependency Inversion Principle**. Services depend on interfaces passed through constructors rather than creating dependencies internally. Thanks to this, the code is less tightly bound to specific implementations. For example, if the storage mechanism changed in the future, the business logic in `RentalService` would require much less modification.

Overall, the project structure aims to keep responsibilities clear, reduce direct dependencies between components, and make future development safer and easier.

## 2. Cohesion, coupling, and class responsibilities.
Cohesion is mainly visible in the service layer and in the way interfaces are defined. Each service is focused on one clearly defined area of responsibility, which makes the code highly cohesive. `EquipmentService` deals with equipment-related operations, `UserService` handles users, and `RentalService` manages rental workflows. Similarly, `ConsoleReportGenerator` is responsible only for generating and displaying reports.

The code also has relatively low coupling. Service classes depend on interfaces rather than concrete classes, which reduces direct dependencies between components. This makes the system easier to maintain and replace piece by piece. A change in one implementation does not automatically require changes in all other parts of the application, as long as the interface remains the same.

The responsibilities of the main classes are clearly separated:
- **Model classes** represent domain objects such as users, equipment, and rentals.
- **`EquipmentService`** is responsible for storing, retrieving, and updating equipment data.
- **`UserService`** manages user storage and retrieval.
- **`RentalService`** contains the main business logic, such as renting equipment, returning it, listing a user’s active rentals, and identifying overdue rentals.
- **`ConsoleReportGenerator`** handles presentation of report data in the console.

An important design idea is that client code works with the system through services rather than directly through the database. The client creates model objects and passes them to the appropriate services, which then manage persistence and business rules. This improves encapsulation and keeps database-related details hidden from higher-level code.

It is also worth noting that `RentalService` acts as the central coordination point of the application, because renting equipment naturally depends on both users and equipment. This is a reasonable design choice, since rental operations combine multiple domain concepts into one business process.

## 3. Why I chose the particular organization of classes, files, and possible project layers.
I decided to separate `Models` and `Services` because they represent two fundamentally different roles in the system. Model classes describe the structure of the business domain, while service classes contain the logic that operates on those models. Keeping them separate makes the architecture clearer and prevents responsibilities from becoming mixed.

The database is also treated as a separate part of the application, because persistence is a different concern from both domain modeling and business logic. This makes the structure closer to a layered design, even if the project is still relatively simple.

I also placed all interfaces inside the `Interfaces` folder. The reason for this is organizational clarity: interfaces define contracts, while service classes provide actual implementations of those contracts. Separating them makes it easier to see which parts of the code describe behavior abstractly and which parts contain executable logic.

Similarly, custom exceptions are grouped in the `Exceptions` folder to improve readability and maintainability. This makes the structure more predictable and helps locate specific types of code more quickly.

More generally, the project is organized in a way that supports future growth. Even though the current application is not very large, this structure would make it easier to expand it later—for example by replacing the console interface with another front end, adding a different database mechanism, or extending the domain with new user or equipment types. In that sense, the organization is not only about readability, but also about keeping the project scalable and easier to modify over time.

