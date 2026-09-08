# Customer Management System

A customer management web application built with C#, ASP.NET Core MVC, Razor views, and Microsoft SQL Server. The project demonstrates a layered architecture, database access through a repository interface, and stored procedures for managing customer records.

## Features

* Create, update, delete, and retrieve customer records.
* View a list of customers and retrieve individual customer details.
* Manage customer information including names and address fields.
* Use Razor views and ASP.NET Core MVC controllers to separate presentation and application logic.
* Execute SQL Server stored procedures through a dedicated class library.

## Technology Stack

| Area          | Technologies                       |
| ------------- | ---------------------------------- |
| Language      | C#                                 |
| Web framework | ASP.NET Core MVC (.NET 8)          |
| Frontend      | Razor Views, HTML, CSS, JavaScript |
| Database      | Microsoft SQL Server               |
| Data access   | Microsoft.Data.SqlClient, ADO.NET  |
| Architecture  | Repository Pattern, Class Library  |
| Development   | Visual Studio                      |

## Architecture

The application separates the web interface from database access.

```text
Razor Views
    ↓
ASP.NET Core MVC Controllers
    ↓
ICustomerRepository
    ↓
CustomerRepository
    ↓
SQL Server Stored Procedures
    ↓
CustomerDB
```

The repository interface defines the customer operations, while `CustomerRepository` implements them using parameterized SQL commands and stored procedures. This separation keeps database access logic outside the MVC controllers.

## Project Structure

```text
customer-management-system/
├── CustomerClassLibrary/
│   ├── Customer.cs
│   ├── ICustomerRepository.cs
│   ├── CustomerRepository.cs
│   └── CustomerClassLibrary.csproj
├── CustomerMVC-CLEAN/
│   ├── Controllers/
│   ├── Models/
│   ├── Properties/
│   ├── Views/
│   ├── wwwroot/
│   ├── appsettings.json
│   ├── CustomerMVC.csproj
│   └── Program.cs
├── CustomerManagementSystem/
│   └── CustomerManagementSystem.sln
├── CustomerDBScript.sql
└── README.md
```

## Database Operations

The repository implements five customer data operations:

| Operation          | Stored Procedure     |
| ------------------ | -------------------- |
| Add customer       | `sp_AddCustomer`     |
| Update customer    | `sp_UpdateCustomer`  |
| Delete customer    | `sp_DeleteCustomer`  |
| Get customer by ID | `sp_GetCustomer`     |
| Get all customers  | `sp_GetAllCustomers` |

SQL parameters are used to pass customer data to the stored procedures, rather than constructing SQL statements through string concatenation.

## Getting Started

### Prerequisites

* Visual Studio with the ASP.NET and web development workload
* .NET 8 SDK
* Microsoft SQL Server or SQL Server Express
* SQL Server Management Studio (recommended)

### 1. Clone the repository

```bash
git clone https://github.com/Noah-Mengesha/customer-management-system.git
```

### 2. Set up the database

Open `CustomerDBScript.sql` in SQL Server Management Studio and execute the script to create the database objects required by the application.

The repository currently uses the following local SQL Server connection configuration:

```text
Server=localhost\SQLEXPRESS;
Database=CustomerDB;
Trusted_Connection=True;
TrustServerCertificate=True;
```

Update the server name or connection configuration to match your local SQL Server installation if necessary.

### 3. Open the solution

Open:

```text
CustomerManagementSystem/CustomerManagementSystem.sln
```

The solution references the MVC application and class library using relative paths. Keep the repository folder structure intact.

### 4. Restore packages and build

Visual Studio should restore the required NuGet packages. The class library uses `Microsoft.Data.SqlClient` for SQL Server connectivity.

Select **Build → Build Solution** and resolve any environment-specific configuration issues.

### 5. Run the application

Set `CustomerMVC` as the startup project and run the application using the HTTPS profile in Visual Studio. Open the local URL provided by Visual Studio.

## What I Learned

This project strengthened my understanding of ASP.NET Core MVC, C# class libraries, SQL Server stored procedures, and separating application logic from data access. It also provided practical experience organizing a multi-project Visual Studio solution, managing NuGet dependencies, and debugging build and project-reference issues.

## Future Improvements

* Move the database connection string into external configuration.
* Add automated unit and integration tests.
* Improve input validation and error handling.
* Add search, filtering, and pagination for customer records.
* Configure a deployment environment.

## Author

**Noah Mengesha**

[GitHub](https://github.com/Noah-Mengesha) | [LinkedIn](https://www.linkedin.com/in/noah-mengesha-63915b265/)
