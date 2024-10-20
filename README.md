# Maui Master-Details CRUD

This project consists of a .NET MAUI application and a backend API, which together demonstrate a simple Master-Details CRUD (Create, Read, Update, Delete) operation. The app allows the user to manage a collection of data objects with the ability to add, edit, delete, and view details of each object.

## Table of Contents
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Setting up the API](#setting-up-the-api)
  - [Running the Application](#running-the-application)
- [Screenshots](#screenshots)
- [Contributing](#contributing)
- [License](#license)

## Features
- Master-Detail layout for displaying and managing data objects.
- Full CRUD functionality:
  - Create new items
  - View details of an item
  - Edit existing items
  - Delete items
- Cross-platform support (Windows, Android, iOS).
- Backend API integration for data persistence.

## Technologies Used
- **.NET MAUI**: Cross-platform framework for building native mobile and desktop apps with .NET.
- **.NET 6 API**: Backend API for handling data operations.
- **MVVM Pattern**: Model-View-ViewModel architecture for separating business logic from UI.
- **SQLite**: Embedded database for local data storage in the MAUI app.
- **Entity Framework Core**: ORM for database management in the API.
- **SQL Server**: Database for backend API.

## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) version 6.0 or later.
- [Visual Studio 2022](https://visualstudio.microsoft.com/) with .NET MAUI and ASP.NET workloads installed.
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) for backend database.

### Setting up the API

1. Clone the API repository:
   ```bash
   git clone https://github.com/xisxus/MauiMasterDetailCrudAPI.git
   ```

2. Navigate to the project directory:
   ```bash
   cd MauiMasterDetailsCrud
   ```

3. Open the solution file in Visual Studio:
   ```bash
   MauiMasterDetailsCrud.sln
   ```

4. Restore dependencies and build the project.

### Running the Application
1. Select the target platform (Windows, Android, iOS) from Visual Studio.
2. Press \`F5\` to build and run the application.

## Screenshots
Null

## Contributing
Contributions are welcome! Please follow these steps to contribute:
1. Fork the repository.
2. Create a new feature branch.
3. Commit your changes.
4. Open a pull request with a detailed description of the changes.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
