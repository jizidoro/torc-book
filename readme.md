front: http://20.85.165.166/book
back: http://4.156.179.83:8080/swagger/index.html

Think about what the search would look like if there were millions of books. How would you make it performant?

1- if it is just for search we can use some database who is epecialized for searching is some domain like cosmodb or elastic search
2- caching logic based on their unique requirements, improving response times and reducing load on the system.
3- we can use a horizontal scaling and load balancing, then we can have more instaces for the search service
4- we can separate the search possibilities in some especialized services
5- we can distribute data across multiple services or workers to improve scalability and performance 


which will be the next steps:

1- we need gateway, who will be responsible for the messages generation that we will use in our message broker
2- we need to finish the implementation of the consumer on the backend side
3- configure the databases
4- decide if we will have a context with a database that is responsible for storing the data a process it(expensive relational database)
and a reading database like cosmodb that is very fast for it, but if we gos for this we will need to make a api responsible for generating those database
view using our relational database, or we can have a mediator who will take care for this part

Hexagonal.API

This is the entry point of the application, typically containing the presentation layer and API endpoints:

    Connected Services: External services that the application might depend on.
    Dependencies: NuGet or other dependencies required by the API project.
    Properties: Project properties such as launchSettings.json.
    Controllers: MVC controllers or API controllers that handle HTTP requests and responses.
    Modules: Organized features or components of the application, which might include:
        appsettings.json: Configuration files for the application.
        BookConsumerService.cs: Likely a service class that consumes messages, possibly from a message queue like RabbitMQ.
        GlobalUsing.cs: Global using directives for the project.
        IRabbitMQConnection.cs & RabbitMQConnection.cs: Interfaces and implementations for connecting to a RabbitMQ service.
        Program.cs: Entry point for configuring and running the ASP.NET Core application.
        Startup.cs: Configures services and the application's request pipeline.

Hexagonal.Application

This layer contains application logic and business rules:

    Bases: Base classes that provide foundational functionality to other classes in this layer.
    Components: They represent the various domain-centric operations that can be performed. BookComponent likely encapsulates business logic related to books, including:
        Commands: Actions that change the state of the application or domain entities.
        Contracts: Interfaces defining behavior contracts that must be implemented, typically by the outer layers.
        Core: Central business logic for the component.
        Queries: Data retrieval operations that do not change the state.
        Validations: Rules to validate that commands and queries are in a correct state before they are executed.
    Mappers: Classes or configurations responsible for mapping between different models (e.g., from domain models to DTOs).
    Paginations: Logic related to dividing data into discrete pages.

Hexagonal.Domain

This layer encapsulates the domain model of the application:

    Bases: Base domain entities or value objects.
    Enums: Enumerations representing sets of named constants.
    Book.cs: A domain entity representing a book.


Hexagonal.Data (3-Driven)

This layer contains elements related to data persistence:

    Bases: Base classes for the data layer, which could include common repository base classes or common data access patterns.
    DataAccess: Specific data access logic or implementations of the repository interfaces.
    Extensions: Helper methods or extension methods that add additional functionality to existing data types or classes.
    Mappings: Configurations for mapping domain entities to database representations, possibly using an ORM like Entity Framework.
    SeedData: Predefined data that can be used to populate the database with initial values during deployment or testing.


The "2-Core" projects contain core business and application rules that should not be dependent on external concerns.
The "3-Driven" projects contain implementations that are driven by the application's needs, such as data access, which adapts the application to different storage technologies.
The architecture enforces a separation of concerns by organizing the application into distinct layers, each with a specific role. This facilitates maintainability and the ability to adapt to changes.
The structure follows the Dependency Inversion Principle, where high-level modules (core logic) do not depend on low-level modules (data access, external services) but rather on abstractions. This is evident by the use of interfaces like 
We also use the repository pattern to facilitate the implementation and the separation of concerns