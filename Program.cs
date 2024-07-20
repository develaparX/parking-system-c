using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        ClearConsole();
        ParkingSystem parkingSystem = new ParkingSystem();

        while (true)
        {
            DisplayMenu();

            Console.Write("Choose an option: ");
            string input = Console.ReadLine();
            if (input == null) continue;

            if (!int.TryParse(input, out int option))
            {
                Console.WriteLine("Invalid input, please enter a number.");
                continue;
            }

            try
            {
                switch (option)
                {
                    case 1:
                        Console.Write("Create Parking Lot: ");
                        if (int.TryParse(Console.ReadLine(), out int numberOfSlots))
                        {
                            parkingSystem.CreateParkingLot(numberOfSlots);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, please enter a number.");
                        }
                        break;

                    case 2:
                        Console.Write("Update Parking Lot: ");
                        if (int.TryParse(Console.ReadLine(), out int updatedNumberOfSlots))
                        {
                            parkingSystem.UpdateParkingLot(updatedNumberOfSlots);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, please enter a number.");
                        }
                        break;

                    case 3:
                        if (!parkingSystem.IsParkingLotCreated())
                        {
                            Console.WriteLine("Parking lot is not created. Please create a parking lot first.");
                            break;
                        }
                        Console.Write("Vehicle Plate Number: ");
                        string registrationNumber = Console.ReadLine();
                        Console.Write("Vehicle Color: ");
                        string color = Console.ReadLine();
                        Console.Write("Vehicle Type (Mobil/Motor): ");
                        if (Enum.TryParse(Console.ReadLine(), true, out VehicleType type))
                        {
                            parkingSystem.ParkVehicle(new Vehicle(registrationNumber, color, type));
                        }
                        else
                        {
                            Console.WriteLine("Invalid vehicle type, please enter 'Mobil' or 'Motor'.");
                        }
                        break;

                    case 4:
                        if (!parkingSystem.IsParkingLotCreated())
                        {
                            Console.WriteLine("Parking lot is not created. Please create a parking lot first.");
                            break;
                        }
                        Console.Write("Select the parking slot for the vehicle that wants to exit: ");
                        if (int.TryParse(Console.ReadLine(), out int slotNumber))
                        {
                            parkingSystem.Leave(slotNumber);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, please enter a number.");
                        }
                        break;

                    case 5:
                        if (!parkingSystem.IsParkingLotCreated())
                        {
                            Console.WriteLine("Parking lot is not created. Please create a parking lot first.");
                            break;
                        }
                        parkingSystem.Status();
                        break;

                    case 6:
                        if (!parkingSystem.IsParkingLotCreated())
                        {
                            Console.WriteLine("Parking lot is not created. Please create a parking lot first.");
                            break;
                        }
                        Console.Write("Vehicle Type (Mobil/Motor): ");
                        if (Enum.TryParse(Console.ReadLine(), true, out VehicleType reportType))
                        {
                            parkingSystem.ReportTypeOfVehicles(reportType);
                        }
                        else
                        {
                            Console.WriteLine("Invalid vehicle type, please enter 'Mobil' or 'Motor'.");
                        }
                        break;

                    case 7:
                        if (!parkingSystem.IsParkingLotCreated())
                        {
                            Console.WriteLine("Parking lot is not created. Please create a parking lot first.");
                            break;
                        }
                        parkingSystem.ReportVehiclesWithOddPlate();
                        break;

                    case 8:
                        if (!parkingSystem.IsParkingLotCreated())
                        {
                            Console.WriteLine("Parking lot is not created. Please create a parking lot first.");
                            break;
                        }
                        parkingSystem.ReportVehiclesWithEvenPlate();
                        break;

                    case 9:
                        if (!parkingSystem.IsParkingLotCreated())
                        {
                            Console.WriteLine("Parking lot is not created. Please create a parking lot first.");
                            break;
                        }
                        Console.Write("Vehicle Color: ");
                        string reportColor = Console.ReadLine();
                        parkingSystem.ReportVehiclesWithColor(reportColor);
                        break;

                    case 10:
                        if (!parkingSystem.IsParkingLotCreated())
                        {
                            Console.WriteLine("Parking lot is not created. Please create a parking lot first.");
                            break;
                        }
                        Console.Write("Vehicle Color: ");
                        string colorForSlots = Console.ReadLine();
                        parkingSystem.ReportSlotsWithColor(colorForSlots);
                        break;

                    case 11:
                        if (!parkingSystem.IsParkingLotCreated())
                        {
                            Console.WriteLine("Parking lot is not created. Please create a parking lot first.");
                            break;
                        }
                        Console.Write("Vehicle Plate Number: ");
                        string reportRegistrationNumber = Console.ReadLine();
                        parkingSystem.ReportSlotForRegistrationNumber(reportRegistrationNumber);
                        break;

                    case 12:
                        Console.WriteLine("Exiting the system.");
                        return;

                    default:
                        Console.WriteLine("Invalid option, please choose a valid menu option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\nWelcome to Develapar Parking System ========================================================");
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Create Parking Lot");
        Console.WriteLine("2. Update Parking Lot");
        Console.WriteLine("3. Park Vehicle");
        Console.WriteLine("4. Leave Vehicle");
        Console.WriteLine("5. Status");
        Console.WriteLine("6. Report Type of Vehicles");
        Console.WriteLine("7. Report Vehicles with Odd Plate Numbers");
        Console.WriteLine("8. Report Vehicles with Even Plate Numbers");
        Console.WriteLine("9. Report Vehicles with Specific Color");
        Console.WriteLine("10. Report Slots with Specific Color");
        Console.WriteLine("11. Report Slot Number for a Vehicle");
        Console.WriteLine("12. Exit");
        Console.WriteLine("======================================================================================");
    }

    static void ClearConsole()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Console.Clear();
        }
        else
        {
            Console.Write("\x1b[3J\x1b[H\x1b[2J");
        }
    }
}
