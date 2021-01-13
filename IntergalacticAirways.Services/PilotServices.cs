using IntergalacticAirways.Models;

namespace IntergalacticAirways.Services
{
    public class PilotServices
    {
        public Pilot GetPilot(HttpClientServices service, string url)
        {
            if (service == null || string.IsNullOrWhiteSpace(url)) return null;

            return service.GetPilot(url).Result;
        }
    }
}
