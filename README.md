# TrackFlow - Hardware Asset Tracker

![.NET CI](https://github.com/HaroonYoldash/trackflow-api/actions/workflows/dotnet.yml/badge.svg)

A full-stack web app built to help small IT teams track workplace hardware such as laptops, monitors, and accessories. It also tracks asset assignments, returns, and audit history.

## Preview

![TrackFlow Dashboard](docs/dashboard.png)

## Why I Built This

Companies can lose track of equipment when hardware is given to employees. Spreadsheets can make it difficult to validate assignments and keep track of who currently has each item.

I built TrackFlow to provide one place to manage assets, assign equipment to staff, prevent duplicate checkouts, and keep a history of asset activity.

## What It Does

* **Inventory Tracking:** Add, view, and manage assets with serial numbers, categories, and purchase costs.
* **Asset Assignment:** Assign assets to staff members and return them to available stock.
* **Audit History:** Records asset events such as creation, assignment, and return, including timestamps and the user responsible.
* **Conflict Prevention:** Prevents an asset that is already assigned from being assigned again.
* **Validation:** Checks required fields and purchase costs before saving data.
* **Fleet Dashboard:** Shows total assets, assigned assets, available assets, and total fleet value.
* **Persistent Storage:** Uses Entity Framework Core with SQLite to store application data.
* **Responsive Dashboard:** Provides a simple web interface with asset search and management features.
* **Automated Tests:** Includes xUnit tests covering the main functionality and edge cases.

## Tech Stack

* **Backend:** C# (.NET 8), ASP.NET Core Web API
* **Database & ORM:** Entity Framework Core with SQLite
* **Testing:** xUnit
* **Frontend:** HTML5, CSS3, JavaScript
* **API Documentation:** Swagger UI
* **CI/CD:** GitHub Actions

## API Endpoints

| Method | Endpoint                   | Description                        |
| ------ | -------------------------- | ---------------------------------- |
| `GET`  | `/api/assets`              | Get all assets                     |
| `GET`  | `/api/assets/{id}`         | Get a specific asset               |
| `GET`  | `/api/assets/{id}/history` | Get the audit history for an asset |
| `POST` | `/api/assets`              | Create a new asset                 |
| `POST` | `/api/assets/{id}/assign`  | Assign an asset to a staff member  |
| `POST` | `/api/assets/{id}/return`  | Return an assigned asset           |

## How to Run Locally

### Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Steps

1. Clone the repository:

```bash
git clone https://github.com/HaroonYoldash/trackflow-api.git
```

2. Open the project folder:

```bash
cd trackflow-api/TrackFlow.Api
```

3. Run the application:

```bash
dotnet run
```

4. Open the URL shown in the terminal.

### Run the Tests

From the main project folder:

```bash
dotnet test
```

## Project Structure

```text
TrackFlow/
├── .github/
│   └── workflows/
│       └── dotnet.yml              # CI build and test pipeline
├── docs/
│   └── dashboard.png               # Dashboard preview
├── tests/
│   └── TrackFlow.Tests/            # xUnit tests
├── TrackFlow.Api/
│   ├── Controllers/                # REST API controllers
│   ├── Data/                       # DbContext and database seeder
│   ├── DTOs/                       # Request and response objects
│   ├── Models/                     # Asset and audit history models
│   ├── wwwroot/                    # Dashboard HTML, CSS and JavaScript
│   └── Program.cs                  # Application configuration
└── TrackFlow.sln                   # Solution file
```

## Features

* Asset management
* Asset assignment and returns
* Audit history
* SQLite database
* Input validation
* REST API
* Swagger documentation
* Responsive web dashboard
* xUnit tests
* GitHub Actions CI
