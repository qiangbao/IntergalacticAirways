namespace IntergalacticAirways.Models
{
    public class PilotStarShip
    {
        private PilotStarShip(string pilotStarShipName, string pilotURL)
        {
            PilotStarShipName = pilotStarShipName;
            PilotURL = pilotURL;
        }
        public string PilotURL { get; set; }
        public string PilotStarShipName { get; set; }

        public static PilotStarShip Create(string pilotStarShipName, string pilotURL) => new PilotStarShip(pilotStarShipName, pilotURL);
    }
}
