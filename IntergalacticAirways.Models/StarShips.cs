using System.Collections.Generic;
using System.Linq;
using IntergalacticAirways.Core;
using IntergalacticAirways.DTO;

namespace IntergalacticAirways.Models
{
    public class StarShips
    {
        public int? Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<StarShip> Results { get; set; }

        public static StarShips FromApi(StarShipsDTO api) =>
            new StarShips
            {
                Count = api.count,
                Next = api.next,
                Previous = api.previous,
                Results = api.results.HasItem() ? api.results.Aggregate(new List<StarShip>(), (items, item) => { items.Add(StarShip.FromApi(item)); return items; }) : null,
            };
    }
}
