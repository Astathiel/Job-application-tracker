# Job-application-tracker

## Description
GUI for tracking ongoing job applications and their states.

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
- C# adn .NET
- Windows Forms (UI)
- JSON (Local data persistance)

## Data Structure and Logic

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
