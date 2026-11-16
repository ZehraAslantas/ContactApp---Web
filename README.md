# 📇 ContactApp

A layered contact management web application built with **ASP.NET Core MVC** (.NET 9). It provides full CRUD operations with persistent SQLite storage, two-tier validation and search, and also displays news fetched from an external **News Web API**.

## 🚀 Key Features

- **Full CRUD:** Create, view, edit and delete contacts with persistent storage.
- **Persistent database:** SQLite storage managed with Entity Framework Core (Code-First migrations). The database is created and seeded automatically on first run.
- **Two-tier validation:**
  - **Client-side:** Instant feedback with jQuery Validation and jQuery Unobtrusive Validation.
  - **Server-side:** `ModelState.IsValid` checks with Data Annotations (`[Required]`, `[EmailAddress]`, `[Phone]`, `[StringLength]`).
- **Search:** Filter contacts by first name, last name or full name through a query string (`?q=`).
- **Post-Redirect-Get (PRG):** Prevents duplicate form submissions on page refresh.
- **CSRF protection:** `[ValidateAntiForgeryToken]` on all state-changing POST requests.
- **Custom 404 page** for contacts that do not exist.
- **Logging:** Create and update operations are logged with `ILogger`.
- **News integration:** The `/news` page lists articles from the News API and shows their details, using a **Typed HttpClient** (`NewsService`) and a `NewsArticleDto`. API errors are caught and logged, so the app keeps working when the API is unreachable.
- **Responsive UI:** Built with Bootstrap 5 and Razor Tag Helpers.

## 🛠️ Tech Stack

- **Framework:** ASP.NET Core MVC (.NET 9)
- **Language:** C#
- **ORM & Database:** Entity Framework Core 9 with SQLite (Code-First)
- **Validation:** Data Annotations, jQuery Validation & Unobtrusive
- **API Client:** Typed HttpClient with DTOs
- **Frontend:** Razor Views, HTML5, CSS3, Bootstrap 5
- **Patterns & Principles:** MVC, Dependency Injection, Repository Pattern, PRG Pattern, Separation of Concerns

## ▶️ Running

**Prerequisites:** .NET 9 SDK

```bash
dotnet run --project ContactApp --launch-profile https
```

Then open **https://localhost:7168**.

> The news page requires the **News API** to be running at `https://localhost:7080/`. This address can be changed in `appsettings.Development.json` (`ApiBaseUrl`).

## 📁 Project Structure

```
ContactApp/
├── Controllers/
│   ├── ContactsController.cs        # Contact CRUD actions, search and validation flow
│   ├── NewsController.cs            # News list and details pages
│   └── HomeController.cs
├── Contracts/
│   └── DTOs/
│       └── NewsArticleDto.cs        # Data shape received from the News API
├── Migrations/                      # EF Core migrations
├── Models/
│   └── Contact.cs                   # Domain entity with Data Annotation rules
├── Repositories/
│   ├── ContactDbContext.cs          # EF Core DbContext (SQLite)
│   ├── EfContactRepository.cs       # EF Core repository implementation
│   └── DbSeeder.cs                  # Initial sample data
├── Services/
│   ├── IContactRepository.cs        # Abstraction for contact operations
│   ├── InMemoryContactRepository.cs # In-memory implementation (alternative to EF Core)
│   ├── INewsService.cs
│   └── NewsService.cs               # Typed HttpClient that calls the News API
├── Views/
│   ├── Contacts/                    # Index, Create, Edit, Details, Delete, NotFound
│   ├── News/                        # Index, Details
│   └── Shared/                      # _Layout, _ValidationScriptsPartial, Error
├── wwwroot/                         # Static assets (Bootstrap, CSS, JS libraries)
├── appsettings.json                 # SQLite connection string
└── Program.cs                       # DI registrations, HttpClient setup, migrations and seeding
```
