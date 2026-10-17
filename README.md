# 📇 Contact Management System (.NET WinForms)

A desktop-based Contact Management System built using **C# Windows Forms** and **.NET**, featuring a structured modular approach for managing contact details with full CRUD (Create, Read, Update, Delete) capabilities, image handling, and robust input validation.

---

## 🚀 Features

1. **Data Display & Grid Management:**
   - Automatically loads and displays all contact records in a `DataGridView` upon launching the main form (`Form1`).

2. **Unified Add/Update Form (`AddUpdateFrm`):**
   - Utilizes a single dynamic form handling both creation and modification modes based on the passed `ContactID` (`-1` for `Add`, or a specific ID for `Update`).

3. **Country Selection (`ComboBox`):**
   - Populates the country dropdown directly from the database to link each contact with their respective country.

4. **Image Management:**
   - Allows users to select a profile image using `OpenFileDialog`.
   - Saves the file path (`ImagePath`) in the database and renders the image inside a `PictureBox` with `Zoom` scaling.
   - Provides a remove button (`linkLabel2`) to clear or delete the selected image.

5. **Input Validation & Error Handling:**
   - Validates mandatory fields instantly using the `Validating` event and `ErrorProvider` component to prevent empty or invalid data submissions.

6. **Interactive Context Menu (`ContextMenuStrip`):**
   - Right-clicking any row in the `DataGridView` accurately selects the row and opens a context menu with options to **Update** or **Delete** the contact.

---

## 📂 Code Architecture & Components

### 1. Main Form (`Form1`)
* **`Form1_Load`**: Fetches all contact records and binds them to the `DataGridView`.
* **`btnAddContact_Click`**: Opens the contact form in `Add` mode by passing an ID of `-1`.
* **`dgv_mouseDown`**: Handles right-click events to select specific grid rows and trigger the context menu.
* **`updateToolStripMenuItem_Click`**: Retrieves the selected contact's ID and opens the form in `Update` mode.
* **`deleteToolStripMenuItem_Click`**: Prompts the user for confirmation, deletes the contact from the database, and refreshes the grid.

### 2. Add/Update Form (`AddUpdateFrm`)
* **Constructor (`AddUpdateFrm(id)`)**: Evaluates the incoming ID to set the form mode (`add` or `update`).
* **`_loadData()`**: Prepares the ComboBox and fetches existing contact details if in `update` mode, including loading profile images and country selections.
* **`btnSave_Click`**: Validates required fields, maps UI inputs to the contact object, handles image paths, and executes the `save()` operation.
* **`validateNotNull`**: Ensures text fields are not left blank using `ErrorProvider`.
* **`linkLabel1_LinkClicked` & `linkLabel2_LinkClicked`**: Handles selecting and removing contact images.

---

## 🛠️ How to Run

1. Open the solution in **Visual Studio**.
2. Ensure your database connection and data layers (`clsContact`, `clsCountries`) are properly configured.
3. Build and run the project to start managing your contacts seamlessly!
