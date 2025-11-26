# 🚀 Object Oriented Programming Project: Corporate Content Management System (CMS)
### Object-Oriented Programming Course Final Project

This project is a comprehensive ASP.NET Web Forms application developed to manage the content of a corporate website. It adheres to modern software engineering principles, utilizing a **4-Layer Architecture (N-Tier)** and **Entity Framework Code-First** approach.

Beyond basic CRUD operations, this project demonstrates advanced capabilities such as **Web API**, **Custom Logging**, **Reporting with Stored Procedures**, and **Design Patterns**.

---

## 🌟 Key Features & Completed Tasks

This project successfully meets **100%** of the academic and technical requirements:

- [x] **N-Layer Architecture:** Separated into Entities, DataAccess, Business, and Web layers.
- [x] **Entity Framework Code-First:** Database schema managed via C# classes and Migrations.
- [x] **Repository Design Pattern:** Centralized data access logic using a generic repository (`GenericRepository<T>`) to prevent code repetition.
- [x] **Admin Panel:** Full CRUD (Create, Read, Update, Delete) pages for 9 different modules.
- [x] **Logging System:** Critical operations and errors are recorded into a `.txt` file using a custom `FileLogger` service and can be viewed via the Admin Panel.
- [x] **Reporting & Stored Procedures:** A visual report page using **Google Charts**, powered by a custom SQL Stored Procedure to calculate project distributions by category.
- [x] **Web Service (API):** An **ASP.NET Web API 2** layer was added to expose project data (e.g., Sliders) to external systems in XML/JSON format.
- [x] **Dynamic Frontend:** The entire public website (Home, About, Services, Portfolio, Contact) is dynamically driven by the database.

---

## 🏗️ Architecture

The solution is divided into 4 main layers and 1 service layer to ensure maintainability and separation of concerns:

| Layer | Project Name | Responsibility |
| :--- | :--- | :--- |
| **1. Entities** | `NtpProje_Entities` | Contains POCO classes representing database tables (e.g., `Slider`, `News`, `LogEntry`). |
| **2. Data Access (DAL)** | `NtpProje_DataAccess` | Handles DB connections (`DbContext`), `Migrations`, `GenericRepository`, and `FileLogger`. |
| **3. Business Logic (BLL)** | `NtpProje_Business` | Contains business rules, validation logic, and Manager classes (`SliderManager`, etc.). Logging integration resides here. |
| **4. Web Interface** | `NtpProje_Web` | The User Interface for the Public Site (`.aspx`) and the Admin Panel (`/Admin`). |
| **5. Service (API)** | `NtpProje_Api` | A RESTful service layer exposing data to external applications. |

---

## 🛠️ Technologies Used

* **Language:** C# (.NET Framework 4.7.2)
* **Web Technology:** ASP.NET Web Forms & ASP.NET Web API 2
* **Database:** SQL Server (LocalDb)
* **ORM:** Entity Framework 6 (Code-First)
* **Visualization:** Google Charts (for Reporting)
* **Logging:** Custom File-Based Logger

---

## 🚀 Setup and Execution

Follow these steps to run the project on your local machine:

1.  **Download:** Clone the repository or download the ZIP file.
2.  **Open:** Open `NtpProje.sln` in Visual Studio.
3.  **Create Database:**
    * Open the **Package Manager Console** in Visual Studio.
    * Set the **Default Project** to `NtpProje_DataAccess`.
    * Run the command: `Update-Database`
4.  **Run the Project:**
    * **For the Website & Admin Panel:** Right-click `NtpProje_Web` and select "Set as Startup Project", then run (`F5`).
    * **For the API:** Right-click `NtpProje_Api`, select "Set as Startup Project", run it, and navigate to `/api/SliderApi` in your browser.

---

## 📊 Admin Panel & Modules

You can access the Admin Panel at: **`http://localhost:port/Admin/AdminDefault.aspx`**

* **Content Management:** Sliders, News, Services, Portfolio, Categories.
* **Corporate:** About Us, Team Members, Contact Information.
* **Inbox:** View/Delete messages sent by visitors via the contact form.
* **Reports:** Visual pie chart showing project distribution (Powered by Stored Procedure).
* **System Logs:** A list of background operations and errors logged by the system.

---

## 📄 License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE.txt) file for details.

---
**Developer:** Kerem Işık
**Date:** November 2025
