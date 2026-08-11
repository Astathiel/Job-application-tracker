# Job-application-tracker

## Description
GUI for tracking ongoing job applications and their current states.

## Features
* Data that can be saved
- Company name
- Location
- Work form(on-site, remote, hybrid)
- Date of the sent application
- Status of the application
* Data saves locally into JSON file
* Edit saved data

## Technologies
- C# and .NET
- Windows Forms (UI)
- JSON (Local data persistance)

## Data Structure and Logic

```mermaid
flowchart TD
        Start([Start the application]) --> CheckFile{Does the data.json exist?}

        CheckFile -- Yes --> LoadData[Load existing data and display it in DataGridView]
        CheckFile -- No --> CreateEmpty([Creates an empty list])

        LoadData --> Idle[Idles/ awaits for user input]
        CreateEmpty --> Idle

        Idle --> ClickSave[Saves user input data into data.json when 'Save' is pressed]

        ClickSave --> Validate[Check if required fields are filled]

        Validate -- No --> ShowError[Shows user a error message if any of the required fields are empty]
        ShowError --> Idle

        Validate -- Yes --> CreateObject[Creates a new JobApplication object]
        CreateObject --> AddToList[Adds object to the memory list]
        AddToList --> SaveJson[Saves the data into data.json by overwriting existing data]
        SaveJson --> RefreshUI[Updates the DataGridView UI]
        RefreshUI --> ClearFields[Clears input fields]
        ClearFields --> Idle

```

### Class Diagram
The application uses a specific data model for job applications

```mermaid
classDiagram
    class tyohakemus {
        +Guid ID
        +string YrityksenNimi
        +string Tyonimike
        +string Paikkakunta
        +string Tyomuoto
        +DateTime Hakupaiva
        +string Tilanne
  }

```

## Project steps
 1. Visual Layout
    - Build the UI.
 3. Data Managment
    - Convert C# data into JSON and save it to local hard drive.
 5. Wiring the events
    - Connect Forms buttons to the logic.
