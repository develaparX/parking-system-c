# Parking System

A console-based parking system developed using .NET 6. This project includes functionalities for creating a parking lot, parking vehicles, checking out vehicles, and generating various reports.

## Features

- Create and update a parking lot with a specified number of slots.
- Park vehicles in available slots. Supports both cars and motorcycles.
- Leave a parking slot, making it available for new vehicles.
- View the status of the parking lot including occupied and available slots.
- Generate reports based on:
  - Types of vehicles
  - Vehicles with odd/even plate numbers
  - Vehicles with specific colors
  - Slot numbers for vehicles with specific registration numbers

## Prerequisites

- .NET 6 SDK

## Getting Started

### Clone the repository

```sh
git clone https://github.com/develaparX/parking-system-c.git
cd parking-system
```

### Build the project
```sh
dotnet build
```

### Run the application
```sh
dotnet run
```

## Usage
Upon running the application, you will be presented with a menu:

```
============================================================
Welcome to Develapar Parking System
============================================================
Menu:
1. Create Parking Lot
2. Update Parking Lot
3. Park Vehicle
4. Leave Vehicle
5. Status
6. Report Type of Vehicles
7. Report Vehicles with Odd Plate Numbers
8. Report Vehicles with Even Plate Numbers
9. Report Vehicles with Specific Registration Numbers
10. Report Slots with Specific Color
11. Report Slot Number for a Vehicle
12. Exit
Choose an option: 
```

### Follow the prompts by choosing the number of menu to interact with the parking system.

### Error Handling

The application will handle errors such as:

- Attempting to park a vehicle before creating a parking lot.
- Inputting an invalid registration number format.
- Attempting to perform operations that are not allowed based on the current state of the parking lot.

### Thank You!