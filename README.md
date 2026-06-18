# 🌍 World Walks API

A RESTful Web API built with ASP.NET Core and PostgreSQL for managing walking trails, regions, and difficulty levels.

This project was developed to practice Backend Development concepts such as:

* ASP.NET Core Web API
* Entity Framework Core
* PostgreSQL
* Repository Pattern
* DTO Pattern
* Dependency Injection
* Custom Action Filters
* Model Validation
* RESTful API Design
* CRUD Operations
* Entity Relationships

---

## 🚀 Technologies Used

### Backend

* ASP.NET Core 9 Web API
* Entity Framework Core
* PostgreSQL

### Development Tools

* Visual Studio Code
* Postman
* pgAdmin 4

---

## 📂 Project Structure

```text
WorldWalks/
│
├── Controllers/
├── Data/
├── Models/
│   ├── Domain/
│   └── DTO/
├── Repositories/
├── CustomActionFilters/
├── Migrations/
└── Program.cs
```

---

## 🏗 Architecture

The application follows a layered architecture:

```text
Controller
    ↓
Repository
    ↓
Entity Framework Core
    ↓
PostgreSQL Database
```

### Repository Pattern

Repositories are used to separate data access logic from controllers.

Benefits:

* Better code organization
* Easier maintenance
* Improved testability
* Reduced coupling

---

## 🗄 Database Design

### Regions

Stores information about walking regions.

| Field          | Type   |
| -------------- | ------ |
| Id             | Guid   |
| Code           | string |
| Name           | string |
| RegionImageUrl | string |

---

### Difficulties

Stores difficulty levels.

| Field | Type   |
| ----- | ------ |
| Id    | Guid   |
| Name  | string |

---

### Walks

Stores walking trail information.

| Field        | Type   |
| ------------ | ------ |
| Id           | Guid   |
| HikerName    | string |
| Name         | string |
| Description  | string |
| LengthInKm   | double |
| RegionId     | Guid   |
| DifficultyId | Guid   |

---

## 🔗 Entity Relationships

```text
Region (1)
   │
   └───────< Walk (Many)

Difficulty (1)
   │
   └───────< Walk (Many)
```

Each walk belongs to:

* One Region
* One Difficulty Level

---

## ✨ Features

### Region Management

* Create Region
* Get All Regions
* Get Region By Id
* Update Region
* Delete Region

### Walk Management

* Create Walk
* Get All Walks
* Get Walk By Id
* Update Walk
* Delete Walk

### Validation

The project uses a custom action filter to validate incoming requests before reaching controller logic.

```csharp
public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result = new BadRequestResult();
        }
    }
}
```

Usage:

```csharp
[ValidateModel]
[HttpPost]
public async Task<IActionResult> Create(...)
{
    ...
}
```

Benefits:

* Centralized validation logic
* Cleaner controllers
* Improved maintainability

---

## 📌 API Endpoints

### Regions

| Method | Endpoint          |
| ------ | ----------------- |
| GET    | /api/regions      |
| GET    | /api/regions/{id} |
| POST   | /api/regions      |
| PUT    | /api/regions/{id} |
| DELETE | /api/regions/{id} |

---

### Walks

| Method | Endpoint        |
| ------ | --------------- |
| GET    | /api/walks      |
| GET    | /api/walks/{id} |
| POST   | /api/walks      |
| PUT    | /api/walks/{id} |
| DELETE | /api/walks/{id} |

---

## ⚙️ Getting Started

### 1. Clone Repository

```bash
git clone https://github.com/your-username/world-walks.git
```

### 2. Navigate to Project

```bash
cd world-walks
```

### 3. Configure Database

Update the connection string in:

```json
appsettings.json
```

Example:

```json
"ConnectionStrings": {
  "WorldWalksConnectionString":
  "Host=localhost;Database=world_walks;Username=postgres;Password=yourpassword"
}
```

### 4. Apply Migrations

```bash
dotnet ef database update
```

### 5. Run Application

```bash
dotnet run
```

The API will start on:

```text
https://localhost:xxxx
```

---

## 🧪 Testing

API endpoints were tested using:

* Postman
* PostgreSQL Queries
* pgAdmin

---

## 📚 Learning Outcomes

Through this project I practiced:

* Building REST APIs with ASP.NET Core
* Designing relational databases
* Using Entity Framework Core
* Working with PostgreSQL
* Implementing Repository Pattern
* Using DTOs for data transfer
* Handling validation with Action Filters
* Managing relationships between entities
* Writing asynchronous code with async/await

---

## 👨‍💻 Author

Developed as a learning project for mastering ASP.NET Core Web API and Backend Development.
