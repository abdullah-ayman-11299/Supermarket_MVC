# Supermarket Management System 🛒

A basic supermarket management system built using **ASP.NET Core MVC**, applying **Clean Architecture** principles.  
This project was created as a learning exercise to practice building real-world backend systems using .NET.

## ✨ Features

- Sell products and track transactions
- Manage categories and products
- View transaction history
- Separation of concerns using Clean Architecture
- Organized using multiple layers:
  - Domain (CoreBusiness)
  - Application Logic (UseCases)
  - Infrastructure (Plugins)
  - UI (Supermarket_MVC - ASP.NET Core MVC)

## 🧱 Project Structure

Supermarket_MVC/

├── CoreBusiness/ // Domain models (Product, Category, Transaction)

├── UseCases/ // Business use cases and interfaces

├── Plugins/ // Data storage (currently in-memory)

├── Supermarket_MVC/ // ASP.NET Core MVC application (UI and controllers)


## 🛠 Technologies Used

- ASP.NET Core MVC (.NET 6)
- C# and OOP
- Clean Architecture pattern
- Git & GitHub
- Entity Framework Core *(planned)*
- SQL Server *(planned)*

## 🚀 Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/Supermarket_MVC.git
   
2.Open the solution in Visual Studio 2022 or later.

3.Run the project (F5 or Ctrl+F5).
