using System.Collections.Generic;

namespace IntergalacticAirways.DTO
{
    public class StarShipsDTO
    {
        public int? count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<StarShipDTO> results { get; set; }
    }
}
