using System.Collections.Generic;
using System.Linq;
using IntergalacticAirways.Core;
using IntergalacticAirways.Models;

namespace IntergalacticAirways.Services
{
    public class StarShipServices
    {
        public (List<PilotStarShip> List, string Next) GetStarShips(HttpClientServices service, string url, int passengerNumber)
        {
            var list = new List<PilotStarShip>();
            string next = null;
            
            var model = service.GetStarShips(url).Result;
            if (model != null)
            {
                next = model.Next;
                var items = model
                    .Results
                    .Where(x => x.Passengers.HasValue && x.Passengers >= passengerNumber)
                    .Select(x => new { x.Name, x.PilotURLs }).ToList();
                if (items.HasItem())
                {
                    foreach (var item in items)
                    {
                        foreach (var pilot in item.PilotURLs)
                        {
                            if (!list.Any(x => x.PilotStarShipName == item.Name && x.PilotURL == pilot))
                            {
                                list.Add(PilotStarShip.Create(item.Name, pilot));
                            }
                        }
                    }
                }
            }

            return (list, next);
        }
    }
}
