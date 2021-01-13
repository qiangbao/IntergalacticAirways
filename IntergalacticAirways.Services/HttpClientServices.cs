using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IntergalacticAirways.DTO;
using IntergalacticAirways.Models;
using Newtonsoft.Json;

namespace IntergalacticAirways.Services
{
    public class HttpClientServices
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public HttpClientServices()
        {
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<StarShips> GetStarShips(string url)
        {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var dto = JsonConvert.DeserializeObject<StarShipsDTO>(content);
                    return StarShips.FromApi(dto);
                }
                return null;
        }

        public async Task<Pilot> GetPilot(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<PilotDTO>(content);
                return Pilot.FromApi(dto);
            }
            return null;
        }
    }
}
