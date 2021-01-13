using System;

namespace IntergalacticAirways.Models
{
    public class BaseModel
    {
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Edited { get; set; }
        public string URL { get; set; }
    }
}
