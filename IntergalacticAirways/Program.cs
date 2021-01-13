using System;
using System.Linq;
using IntergalacticAirways.Core;
using IntergalacticAirways.Models;
using IntergalacticAirways.Services;
using Microsoft.Extensions.Configuration;

namespace IntergalacticAirways
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter Passenger Number: ");
                var passengers = Console.ReadLine();
                int passengerNumber;
                while (!int.TryParse(passengers, out passengerNumber) && passengerNumber > 0)
                {
                    Console.WriteLine("Enter Numeric Passenger Number: ");
                    passengers = Console.ReadLine();
                }


                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();
                var url = configuration.GetSection("StarShips").GetSection("URL").Value;

                var service = new StarShipServices();
                var httpClientServices = new HttpClientServices();
                var pilotService = new PilotServices();

                var model = service.GetStarShips(httpClientServices, url, passengerNumber);
                var list = model.List;
                while (!string.IsNullOrWhiteSpace(model.Next))
                {
                    model = service.GetStarShips(httpClientServices, model.Next, passengerNumber);
                    foreach (var pilot in model.List)
                    {
                        if (!list.Any(x => x.PilotStarShipName == pilot.PilotStarShipName && x.PilotURL == pilot.PilotURL))
                        {
                            list.Add(PilotStarShip.Create(pilot.PilotStarShipName, pilot.PilotURL));
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine(list.HasItem() ? "StarShipName      --- Pilot" : "Cannot find  StarShip.");
                Console.WriteLine();

                foreach (var pair in list)
                {
                    var pilot = pilotService.GetPilot(httpClientServices, pair.PilotURL);
                    if (pilot != null)
                    {
                        Console.WriteLine($"{pair.PilotStarShipName} --- {pilot.Name} ");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Please enter any key to close the window.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
