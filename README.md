# 📇 ContactApp

A responsive, layered Contact Management web application built with ASP.NET Core MVC. This project demonstrates full CRUD (Create, Read, Update, Delete) operations, persistent relational database storage with Entity Framework Core, robust two-tier validation mechanisms, search/filtering, and foundational web security practices.

## 🚀 Key Features
- **Full CRUD Lifecycle:** Create, view, edit, and delete contacts seamlessly with persistent storage.
- **Persistent Relational Database:** Integrated SQLite storage managed via Entity Framework Core with Code-First migrations.
- **Two-Tier Validation (Client & Server):**
  - **Client-Side:** Instant user feedback using jQuery Validate & Microsoft jQuery Unobtrusive scripts without unnecessary round-trips.
  - **Server-Side:** Strict data integrity enforcement via `ModelState.IsValid` and Data Annotations (`[Required]`, `[EmailAddress]`, `[Phone]`, `[StringLength]`).
- **Advanced Model Binding & UI Labels:** Type-safe mapping of HTTP form payloads to C# models, utilizing `[Display]` attributes for dynamic form labels.
- **Search & Filtering:** Dynamic contact filtering via Query String (`q`) without altering underlying storage.
- **Post-Redirect-Get (PRG) Pattern:** Prevents duplicate form submissions on page refresh across form actions.
- **CSRF Protection:** Integrated `[ValidateAntiForgeryToken]` tokens on all state-altering POST requests.
- **Layered Architecture:** Clear separation of concerns between Controllers, Services/Repositories, Data Context, Models, and Views.
- **Responsive UI:** Clean and accessible layout built using Bootstrap 5 and Razor Tag Helpers.

## 🛠️ Tech Stack & Architecture
- **Framework:** ASP.NET Core MVC (.NET 9)
- **Language:** C#
- **ORM & Database:** Entity Framework Core 9 with SQLite (Code-First)
- **Validation Engine:** `System.ComponentModel.DataAnnotations`, jQuery Validation & Unobtrusive
- **Frontend:** Razor Views (`.cshtml`), HTML5, CSS3, Bootstrap 5
- **Patterns & Principles:** MVC, Dependency Injection (IoC), Repository Pattern, PRG Pattern, Separation of Concerns

📁 Project Structure
ContactApp/
├── Controllers/
│   └── ContactsController.cs        # Handles HTTP requests, actions, and validation flow
├── Data/
│   ├── ContactDbContext.cs          # EF Core DbContext configuring SQLite connection
│   └── DbSeeder.cs                  # Initial seed data provider
├── Migrations/                      # EF Core schema snapshots and migration files
├── Models/
│   └── Contact.cs                   # Domain entity with Data Annotation validation rules
├── Repositories/
│   ├── IContactRepository.cs        # Abstraction interface for contact operations
│   ├── EfContactRepository.cs       # Concrete EF Core repository implementation
│   └── InMemoryContactRepository.cs # In-memory implementation for testing/fallback
├── Views/
│   ├── Contacts/
│   │   ├── Create.cshtml            # New contact form with client-side validation
│   │   ├── Edit.cshtml              # Contact update view
│   │   ├── Details.cshtml           # Detailed contact info view
│   │   ├── Delete.cshtml            # Contact deletion confirmation view
│   │   └── Index.cshtml             # Contact listing with search and action buttons
│   └── Shared/
│       ├── _Layout.cshtml           # Main site layout and navigation
│       ├── _ValidationScriptsPartial.cshtml # jQuery validation & unobtrusive script references
│       └── NotFound.cshtml          # Custom 404 error view
├── wwwroot/                         # Static assets (Bootstrap, custom CSS, JS libraries)
├── appsettings.json                 # Configuration and SQLite connection string
└── Program.cs                       # DI container setup, DbContext registration, and middleware pipeline
