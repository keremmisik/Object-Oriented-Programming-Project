# 🚀 Onject Oriented Programming Project: Fully Layered ASP.NET Web Forms Application
## Final Project for Object-Oriented Programming Course

This project was developed to manage the backend of a corporate website, adhering to modern software engineering principles using a **4-Layer Architecture** and the **Entity Framework Code-First** approach.

---

### 🌟 1. CORE TECHNOLOGIES

| Technology | Version / Usage | Description |
| :--- | :--- | :--- |
| **Main Language** | C# (.NET Framework) | Coding of all business and data access logic. |
| **Database** | SQL Server (LocalDb) | Data storage infrastructure. |
| **ORM** | Entity Framework 6.x | Schema generation and data management via Code-First. |
| **Interface (Web)** | ASP.NET Web Forms (.aspx) | User interface and Admin Panel. |
| **Web API (Service)** | `NtpProje_Api` | Layer added to expose project data to the outside world. |

---

### 🧱 2. ARCHITECTURE AND DESIGN PATTERNS (ACADEMIC FOCUS)

The project consists of four distinct layers to meet academic requirements.

#### A. Layered Architecture

| Layer | Project Name | Responsibility |
| :--- | :--- | :--- |
| **Entities** | `NtpProje_Entities` | Contains POCO (Plain Old CLR Object) classes representing database tables (`Slider`, `Portfolio`, `News`, etc.). |
| **Data Access** | `NtpProje_DataAccess` | Includes the database context (`NtpProjeContext`) and the implementation of the **Repository Pattern**. |
| **Business Logic** | `NtpProje_Business` | Houses business rules (Retrieve active items, Ordering, Validation) and Manager classes (`SliderManager`, `PortfolioManager`, etc.). |
| **Web Interface** | `NtpProje_Web` | Contains Admin and Public Site interfaces (`.aspx`). Communicates only with the **Business** layer. |
| **Web API (Service)** | `NtpProje_Api` | The layer added to expose project data via web services. |

#### B. Design Pattern

- **Repository Pattern:** Applied to the `DataAccess` layer. All CRUD (Create/Read/Update/Delete) operations are centralized in the **`GenericRepository<T>`** class. This prevents code repetition and ensures the business logic remains independent of data access technology.

---

### 3. ADVANCED ACADEMIC REQUIREMENTS

This section demonstrates the project's use of advanced capabilities beyond basic CRUD.

| Requirement | Implementation | Description |
| :--- | :--- | :--- |
| **Code-First & Migration** | Fully Implemented | DB schema managed via C#. New fields (`IsActive`, `Order`) were added to the database using Migrations. |
| **Stored Procedure (SP) Usage** | Fully Implemented | SQL code for the project count report (`GetCategoryProjectCounts`) was sent to the database within a Migration. |
| **Reporting** | Fully Implemented | An **Raporlar.aspx** page was added to the Admin Panel, retrieving data from the Stored Procedure and visualizing it (with `Google Charts`). |
| **Admin Panel (CRUD)** | Fully Implemented | CRUD functionalities (**Add/Delete/Edit**) are available for all 9 entities (Slider, Portfolio, News, Team, About, Contact, etc.). |
| **Web Service (API)** | Fully Implemented | The **`NtpProje_Api`** project was created. It serves active Slider data in **XML** or **JSON** format via the `/api/SliderApi` endpoint. |

---

### 4. SETUP AND RUNNING THE PROJECT

1.  **Open the Solution:** Open the `NtpProje.sln` file in Visual Studio.
2.  **Ensure DLLs are Present:** Make sure all necessary NuGet packages (especially Entity Framework) are installed across the solution.
3.  **Create the Database:** In the **Package Manager Console**, with `NtpProje_DataAccess` selected as the default project, run:
    ```powershell
    Update-Database
    ```
4.  **Populate Admin Data:** Set `NtpProje_Web` as the startup project and run it. Navigate to `Admin/AdminDefault.aspx` (or use the left menu) to enter necessary data (Sliders, Categories, About Content).
5.  **Test the API:** Set `NtpProje_Api` as the startup project, run it, and check the `/api/SliderApi` address in the browser.

---
**Project Developer:** Kerem Işık
**Date:** November 26, 2025
