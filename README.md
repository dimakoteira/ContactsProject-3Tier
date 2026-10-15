# Contacts & Countries Management System

A robust, enterprise-grade desktop management application built using **C#**, **ADO.NET**, and a strict **3-Tier Architecture**. This project demonstrates best practices in clean code architecture, data integrity, secure database interactions, and robust state management.

---

## 🏗️ Architectural Overview

The application follows the **3-Tier Architecture** pattern to ensure separation of concerns, maintainability, and scalability:

1. **Presentation Layer (Console / UI):** Acts as the entry point, handling user interaction, input formatting, and validation (e.g., strict type checking using `TryParse`).
2. **Business Layer (BLL):** Contains the core business logic, domain models, entity states (`enMode`), and validation rules. It communicates with the Data Layer using **Data Transfer Objects (DTOs)**.
3. **Data Layer (DAL):** Manages direct database communication, executing parameterized SQL commands via `ADO.NET` (`SqlConnection`, `SqlCommand`, `SqlDataReader`) and handling database exceptions.

---

## ✨ Key Features & Technical Highlights

### 1. Full CRUD Operations
* **Contacts & Countries:** Complete Create, Read, Update, and Delete operations for both entities.
* **Advanced Search:** Find records efficiently by ID or Name, returning fully populated domain objects or lightweight existence checks.

### 2. Smart State Management (`enMode` & `Save`)
* Implements a unified `Save()` method in the business layer driven by an `enMode` state machine (`AddNew` vs. `Update`).
* Automatically transitions a newly inserted record's state to `Update` upon successful database insertion, preventing duplicate entries.

### 3. Data Integrity & Foreign Key Constraint Handling
* **Safe Deletion:** Before deleting a country, the system validates whether it is linked to any active contacts (`IsCountryLinkedToContact`) to prevent foreign key constraint violations.
* **Existence Validation:** Dedicated `IsExist` methods optimized with lightweight queries (`SELECT 1`) to check record existence without fetching heavy data payloads.

### 4. Robust Null-Safety & Data Mapping
* **Database to App:** Safely handles nullable database fields using `DBNull.Value` checks to prevent cast exceptions and assign clean fallback values.
* **App to Database:** Features a custom utility helper (`isNull`) that maps empty strings or user-skipped inputs (`Enter`) into genuine `DBNull.Value` instances before saving.
* **Presentation Validation:** Enforces mandatory fields and data-type constraints in the UI layer (`int.TryParse`, `DateTime.TryParse`, and character filtering).

### 5. Security & Error Handling
* **SQL Injection Prevention:** 100% reliant on parameterized queries (`Parameters.AddWithValue`) across all database interactions.
* **Silent Exception Logging:** Centralized `try-catch` blocks catch exceptions and log detailed error messages with timestamps into dedicated text files (`ExceptionsLOG.txt` and `ExceptionsLOGcountries.txt`) without exposing raw stack traces to end-users.

---

## 🛠️ Tech Stack & Tools

* **Language:** C# (.NET)
* **Data Access:** ADO.NET (`System.Data.SqlClient`)
* **Database:** Microsoft SQL Server
* **Architecture:** 3-Tier (DTO Pattern, Separation of Concerns)
* **Version Control:** Git & GitHub

---

