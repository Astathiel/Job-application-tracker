### How the App Works & User Guide

```markdown
# Job Application Tracker - User & Technical Guide

## How Data Storage Works
- **Local Persistence:** The application stores all records locally on your computer.
- **Directory Structure:** Upon launch, the app automatically creates an `Applications` folder inside your executable directory, safely housing your `data.json` file.
- **Non-Destructive View Logic:** Filtering and sorting operate on a temporary memory copy (the View) derived from your master list (the Vault). This ensures your master data is never accidentally corrupted or deleted during UI filtering.

---

## User Instructions

1. **Launch the Application:** Start the application. It will automatically check for an existing `data.json` file inside the `Applications` folder and load your entries into the data grid. If it's a fresh launch, it populates with sample data or an empty list.
2. **Add an Entry:** Fill out the input fields (Company Name, Role/Title, Location, Working Method, Application Date, and Status) and click the **Save** button. The app validates required fields before appending the entry and updating the local JSON file.
3. **Edit an Entry:** Click the pencil (edit) icon on the right side of any row. This pulls the record back into the top input fields so you can modify details and save changes.
4. **Delete an Entry:** Click the trash can (delete) icon on any row to instantly remove it from the data grid and sync the updated list to the local storage file.
5. **Sort Data:** Click on any table column header (e.g., "Company Name" or "Date") to toggle between ascending and descending alphabetical/chronological sorting.
6. **Filter Data:** Click the **Filter** button to open the categorized dropdown menu. You can isolate applications by their status (Applied, Pending, Interview, Offer, Rejected) or work model (Remote, Hybrid, On-site) without losing hidden records.
