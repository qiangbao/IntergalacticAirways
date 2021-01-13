using System.Collections.Generic;

using IntergalacticAirways.Core;
using IntergalacticAirways.DTO;

namespace IntergalacticAirways.Models
{
    public class StarShip : BaseModel
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public long? CostInCredits { get; set; }
        public decimal? Length { get; set; }
        public long? MaxAtmospheringSpeed { get; set; }
        public int? Crew { get; set; }
        public int? Passengers { get; set; }
        public long? CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public decimal? HyperdriveRating { get; set; }
        public long? MGLT { get; set; }
        public string StarShipClass { get; set; }
        public List<string> PilotURLs { get; set; }
        public List<string> FilmURLs { get; set; }
        
        public static StarShip FromApi(StarShipDTO api) =>
         new StarShip
         {
                Name = api.name,
                Model = api.model,
                Manufacturer = api.manufacturer,
                CostInCredits = api.cost_in_credits.ToLong(),
                Length = api.length.ToDecimal(),
                MaxAtmospheringSpeed = api.max_atmosphering_speed.ToLong(),
                Crew =api.crew.ToInt(),
                Passengers = api.passengers.ToInt(),
                CargoCapacity = api.cargo_capacity.ToLong(),
                Consumables = api.consumables,
                HyperdriveRating = api.hyperdrive_rating.ToDecimal(),
                MGLT = api.MGLT.ToLong(),
                StarShipClass = api.starship_class,
                PilotURLs = api.pilots,
                FilmURLs = api.films,
                Created = api.created.ToDateTime(),
                Edited = api.edited.ToDateTime(),
                URL = api.url,
            };
    }
}
