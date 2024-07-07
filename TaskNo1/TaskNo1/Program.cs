using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TripManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string filePath = "trips.csv";

           
            List<Trips> tripsList = new List<Trips>();

          
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    
                    reader.ReadLine();

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');

                        if (values.Length == 3)
                        {
                            string country = values[0];
                            string person = values[1];
                            int days = int.Parse(values[2]);

                            Trips trip = new Trips(country, person, days);
                            tripsList.Add(trip);
                        }
                    }
                }

                Console.WriteLine("Data successfully read from CSV file and Trips objects created.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            ListTrips(tripsList);
            
            while (true)
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1. List Trips");
                Console.WriteLine("2. Add Trip");
                Console.WriteLine("3. Calculate Average Stay");
                Console.WriteLine("4. Save Average Stay");
                Console.WriteLine("5. Exit");
                Console.Write("\nYour choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListTrips(tripsList);
                        break;
                    case "2":
                        AddTrip(tripsList, filePath);
                        break;
                    case "3":
                        CalculateAverageStay(tripsList);
                        break;
                    case "4":
                        SaveAverageStay(tripsList);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        static void ListTrips(List<Trips> tripsList)
        {
            Console.WriteLine("\n--- Trips ---");
            foreach (var trip in tripsList)
            {
                Console.WriteLine($"Country: {trip.Country}, Person: {trip.Person}, Days: {trip.Days}");
            }
        }

        static void AddTrip(List<Trips> tripsList, string filePath)
        {
            Console.Write("\nCountry: ");
            string country = Console.ReadLine();

            Console.Write("Person: ");
            string person = Console.ReadLine();

            Console.Write("Number of days: ");
            int days = int.Parse(Console.ReadLine());

            Trips trip = new Trips(country, person, days);
            tripsList.Add(trip);

           
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{country},{person},{days}");
                }

                Console.WriteLine("New trip successfully added and saved to the file.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        static void CalculateAverageStay(List<Trips> tripsList)
        {
            var averageStays = tripsList
                .GroupBy(t => t.Person)
                .Select(g => new
                {
                    Person = g.Key,
                    AverageStay = g.Average(t => t.Days)
                })
                .ToList();

            Console.WriteLine("\nAverage Stay per Person:");
            foreach (var item in averageStays)
            {
                Console.WriteLine($"Person: {item.Person}, Average Stay: {item.AverageStay:F2} days");
            }
        }

        static void SaveAverageStay(List<Trips> tripsList)
        {
            var averageStays = tripsList
                .GroupBy(t => t.Person)
                .Select(g => new
                {
                    Person = g.Key,
                    AverageStay = g.Average(t => t.Days)
                })
                .ToList();

            string avgFilePath = "avg_days.csv";
            try
            {
                using (StreamWriter writer = new StreamWriter(avgFilePath))
                {
                    writer.WriteLine("person,average_stay");

                    foreach (var item in averageStays)
                    {
                        writer.WriteLine($"{item.Person},{item.AverageStay:F2}");
                    }
                }

                Console.WriteLine($"Average stays successfully saved to {avgFilePath}.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }


}
