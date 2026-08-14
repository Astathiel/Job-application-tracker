# Job Application Tracker

## Project Overview
A Windows Forms desktop application designed to track job applications using a modern, minimalistic user interface and local JSON storage. 

## Progress Log

### Step 1: Initial Form and Data Persistence
* **Data Model:** Created the `JobApplication` class to define the data structure (Company Name, Job Title, Location, Work Model, Application Date, Status).
* **Storage System:** Implemented a static `DataManager` class utilizing `System.Text.Json` to serialize and deserialize application data to a local `data.json` file.
* **User Interface:** Designed a top-and-bottom layout featuring input fields and a data grid.
* **Programmatic Styling:** Bypassed default Windows Forms 3D visual styles using a centralized `ApplyModernStyles` method to achieve a flat, minimalistic aesthetic (white background, flat borders, custom data grid rendering, and dynamic footer counts).
* **Data Binding:** Connected the frontend inputs to the backend logic, allowing the application to save new entries to the JSON file, load existing entries on startup, and refresh the UI ledger.

### Pending Steps
* Step 2: Add edit and delete buttons.
* Step 3: Add sort and filter buttons.