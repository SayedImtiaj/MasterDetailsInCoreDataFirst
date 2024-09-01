# MasterDetailsInCoreDataFirstApproach

`MasterDetailsInCoreDataFirstApproach` is an ASP.NET Core MVC application that demonstrates the Master-Detail design pattern using Entity Framework Core with a Data-First approach. This project showcases how to manage relationships between master and detail entities in a web application.

## Features

- **Master-Detail Relationship:** Manage and display master-detail relationships effectively.
- **Data-First Approach:** Generate Entity Framework models from an existing database schema.
- **CRUD Operations:** Create, read, update, and delete operations for both master and detail entities.
- **ASP.NET Core MVC:** Utilizes the Model-View-Controller pattern to structure the application.

## Getting Started

To set up and run the application locally, follow these steps:

### Prerequisites

Ensure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any compatible database

### Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/ChowdhuryMunir/MasterDetailsInCoreDataFirstApproach.git
   ```

2. **Navigate to the project directory:**

   ```bash
   cd MasterDetailsInCoreDataFirstApproach
   ```

3. **Install dependencies:**

   The project dependencies are managed via NuGet. Restore them using:

   ```bash
   dotnet restore
   ```

4. **Update the database connection string:**

   Edit the `appsettings.json` file to include your database connection string:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
   }
   ```

5. **Apply database migrations (if applicable):**

   If there are any pending migrations, apply them using:

   ```bash
   dotnet ef database update
   ```

6. **Run the application:**

   Start the application using:

   ```bash
   dotnet run
   ```

   The application will be available at `http://localhost:5000` (or the port specified in `launchSettings.json`).

## Project Structure

- **Models:** Contains the entity classes generated from the existing database schema.
- **Data:** Includes the `DbContext` and configuration for Entity Framework Core.
- **Controllers:** Implements MVC controllers for handling user interactions and data processing.
- **Views:** Contains Razor views for displaying data and user interfaces.
- **wwwroot:** Static files like CSS, JavaScript, and images.

## Application Features

### Master Entity Management

- **List Master Entities:** Displays a list of master entities.
- **Create Master Entity:** Form to add a new master entity.
- **Edit Master Entity:** Form to update existing master entity details.
- **Delete Master Entity:** Option to remove a master entity.

### Detail Entity Management

- **List Detail Entities:** Displays a list of detail entities associated with a selected master entity.
- **Create Detail Entity:** Form to add a new detail entity.
- **Edit Detail Entity:** Form to update existing detail entity details.
- **Delete Detail Entity:** Option to remove a detail entity.

### Navigation

- **Master-Detail Views:** Easily navigate between master and detail views to manage data relationships.

## Usage

Navigate to `http://localhost:5000` in your web browser to access the application. Use the navigation menu to interact with master and detail entities.

## Contributing

We welcome contributions from the community! To contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -m 'Add new feature'`).
4. Push the branch (`git push origin feature/your-feature`).
5. Open a pull request describing your changes.


## License

This project is licensed under the [MIT License](LICENSE). See the [LICENSE](LICENSE) file for more information.

## Contact

For questions or feedback, please contact [MunirchowdhurySaif ](mailto:munir.idb@gmail.com).

---
