# 🚗DriveEase-Car Rental Website🚗


## 📘Overview
DriveEase is a complete car rental website built using the ASP.NET Core MVC framework. It provides a clean, modern interface for two types of users: Users (customers) who can browse and book vehicles, and Admins who can manage the vehicle fleet and customer bookings.

## 💻Tech Stack
This project is built with a modern .NET and web stack:

🧠Backend: ASP.NET Core MVC (.NET 8 / .NET 6+)

🧰Language: C#

🎨Frontend: HTML5, CSS3, JavaScript (ES6+)

## ⚙️Steps To Run:
### ✅Prerequisites

1. .NET SDK (Version 6.0 or newer)

2. A code editor like Visual Studio or VS Code

### ▶️Running the Project

1. Clone the repository (or download and unzip the project files).

2. Open a terminal or command prompt in the project's root folder

3. Restore Dependencies:
```bash
dotnet restore
```

4. Run:
```bash
dotnet run
```
Open your browser and navigate to the local URL shown in the terminal (usually `http://localhost:5123` or `https://localhost:7123`).

## 📊Project Flowchart

```mermaid
flowchart TD
    A[CarRentalMvc] --> B[Controllers]
    B --> B1[AccountController.cs]
    B --> B2[AdminController.cs]
    B --> B3[HomeController.cs]

    A --> C[Data]
    C --> C1[MockDataService.cs]

    A --> D[Models]
    D --> D1[AdminDashboardViewModel.cs]
    D --> D2[Booking.cs]
    D --> D3[Car.cs]
    D --> D4[LoginViewModel.cs]

    A --> E[Views]
    E --> E1[Account/]
    E --> E2[Admin/]
    E --> E3[Home/]
    E --> E4[Shared/_Layout.cshtml]

    A --> F[wwwroot]
    F --> F1[css/site.css]
    F --> F2[js/site.js]

    A --> G[Program.cs]
    A --> H[CarRentalMvc.csproj]
```

## 👤About the Author

This Car Rental Website(DriveEase) is developed by [Divy Lathiya](https://github.com/DivyLathiya).

🎉Thank You for Visiting.🎉
