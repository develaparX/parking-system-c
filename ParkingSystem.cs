using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class ParkingSystem
{

    private Dictionary<int, Vehicle> parkingSlots = new Dictionary<int, Vehicle>();
    private int totalSlots;

    public void CreateParkingLot(int slots)
    {
        totalSlots = slots;
        parkingSlots = new Dictionary<int, Vehicle>();
        Console.WriteLine($"Created a parking lot with {slots} slots.");
    }

    public void ParkVehicle(Vehicle vehicle)
    {
        if (!IsValidRegistrationNumber(vehicle.RegistrationNumber))
        {
            Console.WriteLine("Invalid registration number format. Allowed formats: XX-XXXX-XXX, X-XXXX-XX, X-XXXX-XXX");
            return;
        }

        if (parkingSlots.Count >= totalSlots)
        {
            Console.WriteLine("Sorry, parking lot is full.");
            return;
        }

        for (int i = 1; i <= totalSlots; i++)
        {
            if (!parkingSlots.ContainsKey(i))
            {
                parkingSlots[i] = vehicle;
                Console.WriteLine($"Allocated slot number: {i}");
                return;
            }
        }
    }

    public void Leave(int slotNumber)
    {
        if (parkingSlots.ContainsKey(slotNumber))
        {
            parkingSlots.Remove(slotNumber);
            Console.WriteLine($"Slot number {slotNumber} is free");
        }
        else
        {
            Console.WriteLine("Not found");
        }
    }

    public void Status()
    {
        if (parkingSlots.Count == 0)
        {
            Console.WriteLine("No vehicles parked.");
            return;
        }

        Console.WriteLine("Slot No.   Type   Registration No   Colour");
        foreach (var slot in parkingSlots)
        {
            Console.WriteLine($"{slot.Key,-11}{slot.Value.Type,-8}{slot.Value.RegistrationNumber,-18}{slot.Value.Color}");
        }
    }

    private bool IsValidRegistrationNumber(string registrationNumber)
    {
        string pattern = @"^[A-Z]{1,2}-\d{4}-[A-Z]{2,3}$";
        return Regex.IsMatch(registrationNumber, pattern);
    }
    public void UpdateParkingLot(int numberOfSlots)
    {
        totalSlots = numberOfSlots;
        parkingSlots = new Dictionary<int, Vehicle>(numberOfSlots);
        Console.WriteLine($"Updated the parking lot to {numberOfSlots} slots");
    }


    public void ReportTypeOfVehicles(VehicleType type)
    {
        int count = parkingSlots.Values.Count(v => v.Type == type);
        if (count == 0)
        {
            Console.WriteLine("Not found");
        }
        else
        {
            Console.WriteLine(count);
        }
    }

    public void ReportVehiclesWithOddPlate()
    {
        var vehicles = parkingSlots.Values.Where(v => IsOddPlate(v.RegistrationNumber)).ToList();
        if (vehicles.Count == 0)
        {
            Console.WriteLine("Not found");
        }
        else
        {
            Console.WriteLine(string.Join(", ", vehicles.Select(v => v.RegistrationNumber)));
        }
    }

    public void ReportVehiclesWithEvenPlate()
    {
        var vehicles = parkingSlots.Values.Where(v => !IsOddPlate(v.RegistrationNumber)).ToList();
        if (vehicles.Count == 0)
        {
            Console.WriteLine("Not found");
        }
        else
        {
            Console.WriteLine(string.Join(", ", vehicles.Select(v => v.RegistrationNumber)));
        }
    }

    public void ReportVehiclesWithColor(string color)
    {
        var vehicles = parkingSlots.Values.Where(v => v.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).ToList();
        if (vehicles.Count == 0)
        {
            Console.WriteLine("Not found");
        }
        else
        {
            Console.WriteLine(string.Join(", ", vehicles.Select(v => v.RegistrationNumber)));
        }
    }

    public void ReportSlotsWithColor(string color)
    {
        var slots = parkingSlots.Where(s => s.Value.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).ToList();
        if (slots.Count == 0)
        {
            Console.WriteLine("Not found");
        }
        else
        {
            Console.WriteLine(string.Join(", ", slots.Select(s => s.Key)));
        }
    }

    public void ReportSlotForRegistrationNumber(string registrationNumber)
    {
        var slot = parkingSlots.FirstOrDefault(s => s.Value.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase)).Key;
        if (slot == 0)
        {
            Console.WriteLine("Not found");
        }
        else
        {
            Console.WriteLine(slot);
        }
    }

    private bool IsOddPlate(string registrationNumber)
    {
        string[] parts = registrationNumber.Split('-');
        if (parts.Length >= 2 && int.TryParse(parts[1], out int number))
        {
            return number % 2 != 0;
        }
        return false;
    }

    public bool IsParkingLotCreated()
    {
        return totalSlots > 0 && parkingSlots != null;
    }
}
