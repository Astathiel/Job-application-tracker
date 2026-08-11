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
        ClearFieldss --> Idle
