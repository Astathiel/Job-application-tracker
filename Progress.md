# Job Application Tracker

## Project Overview
A Windows Forms desktop application designed to track job applications using a modern, minimalistic user interface and local JSON storage.

## Progress Log

### Pre-Start: UI/UX Design (Completed)
* **Design Phase:** Conceptualized and designed the application interface using Figma before to development.
* **Blueprint Creation:** Exported the final minimalistic layout as `JobApplicationTracker_Minimalistic.pdf` to serve as the visual and structural reference for the C# Windows Forms styling.

### Step 1: Core Foundation & Data Persistence (Completed)
* **Data Model:** Created the `JobApplication` class to define the data structure (Company Name, Job Title, Location, Work Model, Application Date, Status).
* **Storage System:** Implemented a static `DataManager` class utilizing `System.Text.Json` to serialize and deserialize application data to a local `data.json` file.
* **User Interface:** Designed a top-and-bottom layout featuring input fields and a data grid.
* **Programmatic Styling:** Bypassed default Windows Forms 3D visual styles using a centralized `ApplyModernStyles` method to achieve a flat, minimalistic aesthetic (white background, flat borders, custom data grid rendering, and dynamic footer counts).
* **Data Binding:** Connected the frontend inputs to the backend logic, allowing the application to save new entries to the JSON file, load existing entries on startup, and refresh the UI ledger.
* **Window Title:** Updated the main application window title to reflect the project name.

### Step 2: Modification & Deletion (Completed)
* **UI Integration:** Programmatically inject flat, styled "Edit" and "Delete" button columns directly into the data table rows.
* **State Memory:** Introduce a tracking variable to the form to remember if the user is currently updating an existing application or creating a brand new one.
* **Event Logic:** Wire up a cell-click event so that clicking "Delete" removes the entry and rewrites the JSON, while clicking "Edit" pulls the row's data back into the top input fields for modification.

### Step 3: Data Organization (Pending)
* **User Interface:** Build and style Sort and Filter buttons.
* **Backend Logic:** Implement logic to arrange the data grid by criteria (e.g., Application Date, Status) and hide rows that do not match the selected filters.

### Step 4: Layout Polish, Dark Mode & Directory Management (Pending)
* **Directory Management:** Update the `DataManager` to automatically generate an "Applications" folder to safely house the `data.json` file.
* **Table Readability:** Command the `DataGridView` to auto-size its columns to fill the entire window width, and manually override the header text for improved readability.
* **Theme Manager:** Create a dedicated `ThemeManager` class utilizing Object-Oriented Programming (OOP) principles to handle the swapping of Light and Dark color palettes, keeping the main form clean and modular.

## Time Investment Log

**Total Time Spent:** [26] hours

| Date         | Development Phase / Tasks Completed                                     | Hours Spent |
|--------------|-------------------------------------------------------------------------|-------------|
| [11.08.2026] | Pre-Start: Decide the project theme. Create github repository to track the project. Create class Diagram and flowchart.                                     |     [3h]    |
| [13.08.2026] | Pre-Start: Figma UI/UX prototyping and blueprint creation | [5h] |
| [13.08.2026] | Step 1: Initial form setup, JSON storage integration, and data binding | [6h] |
| [14.08.2026] | Step 4 (Partial): Directory management anchoring and table readability polish | [4h] |
| [17.08.2026] | Step 4 (Partial): ThemeManager OOP class creation | [3h] |
| [18.08.2026] | Step 4 (Completed): Dark Mode toggle finalization, embedded grid icons, and Edit/Delete JSON syncing. | [5h] |
| [18.08.2026] | Step 5 (In progress): Sort and Filter functions | [X.X] |
