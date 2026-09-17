\# TrackFlow - Hardware Asset Tracker



A full-stack web app I built to help small IT teams keep track of office hardware (like laptops and monitors) and see who currently has them checked out.



\## Why I Built This



Companies often lose track of equipment when handing out laptops and accessories to employees. I wanted to build a practical tool that stores inventory, handles lending/returning equipment, and stops common human errors (like giving the same laptop to two people at once).



\## What It Does



\- \*\*Full Inventory Tracking:\*\* Add, edit, view, and remove devices with their serial numbers and purchase costs.

\- \*\*Assignment System:\*\* Assign items to staff members or return them to available inventory.

\- \*\*Safety Checks:\*\*

&#x20; - Prevents assigning an item that someone is already using (returns a 409 Conflict).

&#x20; - Validates all input data (e.g. costs must be positive numbers, names cannot be blank).

\- \*\*Persistent Storage:\*\* Uses SQLite so data remains saved even after restarting the app.

\- \*\*Web Interface:\*\* A lightweight frontend dashboard using plain HTML, CSS, and JavaScript so anyone can test the system in their browser.

\- \*\*Unit Tests:\*\* Automated tests using xUnit to make sure database queries and edge cases work properly.



\## Tech Stack



\- \*\*Backend:\*\* C# (.NET 8), ASP.NET Core Web API

\- \*\*Database:\*\* Entity Framework Core with SQLite

\- \*\*Testing:\*\* xUnit (using in-memory database instances for test isolation)

\- \*\*Frontend:\*\* HTML, CSS, JavaScript (Fetch API)

\- \*\*API Testing:\*\* Swagger UI



\## How to Run It Locally



\### Requirements



\- \[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)



\### Steps



1\. Clone the project:

&#x20;  ```bash

&#x20;  git clone \[https://github.com/HaroonYoldash/trackflow-api.git](https://github.com/HaroonYoldash/trackflow-api.git)

&#x20;  cd trackflow-api/TrackFlow.Api

