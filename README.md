\# TrackFlow - Hardware Asset Tracker

![.NET CI](https://github.com/HaroonYoldash/trackflow-api/actions/workflows/dotnet.yml/badge.svg)

A full-stack web app I built to help small IT teams keep track of office hardware...

A full-stack web app I built to help small IT teams keep track of office hardware such as laptops and monitors, and see who currently has them checked out.



\## Why I Built This



Companies can lose track of equipment when giving laptops and accessories to employees. I wanted to build a practical tool that stores inventory, handles lending and returning equipment, and prevents common mistakes such as assigning the same laptop to two people at the same time.



\## What It Does



\* \*\*Inventory Tracking:\*\* Add, edit, view, and remove devices with their serial numbers and purchase costs.

\* \*\*Assignment System:\*\* Assign items to staff members or return them to available inventory.

\* \*\*Validation:\*\* Checks input data, such as positive costs and required names.

\* \*\*Conflict Prevention:\*\* Prevents an item that is already assigned from being assigned again.

\* \*\*Persistent Storage:\*\* Uses SQLite so data stays saved after restarting the application.

\* \*\*Web Dashboard:\*\* A simple frontend using HTML, CSS, and JavaScript.

\* \*\*Unit Tests:\*\* Uses xUnit tests to check the main functionality and edge cases.



\## Tech Stack



\* \*\*Backend:\*\* C# (.NET 8), ASP.NET Core Web API

\* \*\*Database:\*\* Entity Framework Core with SQLite

\* \*\*Testing:\*\* xUnit

\* \*\*Frontend:\*\* HTML, CSS, JavaScript

\* \*\*API Testing:\*\* Swagger UI



\## How to Run It Locally



\### Requirements



\* \[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)



\### Steps



1\. Clone the project:



```bash

git clone https://github.com/HaroonYoldash/trackflow-api.git

```



2\. Open the project folder:



```bash

cd trackflow-api/TrackFlow.Api

```



3\. Run the application:



```bash

dotnet run

```



4\. Open the URL shown in the terminal.



\### Run the Tests



From the main project folder, run:



```bash

dotnet test

```



\## Project Structure



```text

TrackFlow.Api/

├── Controllers/

├── Data/

├── DTOs/

├── Models/

├── wwwroot/

└── Program.cs



tests/

└── TrackFlow.Tests/

```



\## Features



\* Manage hardware assets

\* Assign assets to staff

\* Return assigned assets

\* SQLite database

\* Input validation

\* REST API

\* Swagger documentation

\* Web dashboard

\* Automated xUnit tests



