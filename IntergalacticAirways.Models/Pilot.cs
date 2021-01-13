using System.Collections.Generic;
using IntergalacticAirways.Core;
using IntergalacticAirways.DTO;

namespace IntergalacticAirways.Models
{
    public class Pilot : BaseModel
    {
        private Pilot() { }
        public decimal? Height { get; set; }
        public decimal? Mass { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public string HomeWorldURL { get; set; }
        public List<string> FilmURLs { get; set; }
        public List<string> SpecieURLs { get; set; }
        public List<string> VehicleURLs { get; set; }
        public List<string> StarShipURLs { get; set; }

        

        public static Pilot FromApi(PilotDTO api) => 
        new Pilot
        {
            Name = api.name,
            Height = api.height.ToDecimal(),
            Mass = api.mass.ToDecimal(),
            HairColor = api.hair_color,
            SkinColor = api.skin_color,
            EyeColor = api.eye_color,
            BirthYear = api.birth_year,
            Gender = api.gender,
            HomeWorldURL = api.homeworld,
            FilmURLs = api.films,
            SpecieURLs = api.species,
            VehicleURLs = api.vehicles,
            StarShipURLs = api.starships,
            Created = api.created.ToDateTime(),
            Edited = api.edited.ToDateTime(),
            URL = api.url,
        };
    }
}
