using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eSport
{
    public class GameType
    {
        [Required]
        public string description { get; set; }
        public int numberOfOutcomes { get => outcomeOdds.Count; }

        [Required]
        public Dictionary<string, float> outcomeOdds { get; set; } = new Dictionary<string, float>();
        public GameType()
        {
        }

        /*
        public GameType(string name, Dictionary<string, float> oddsList)
        {
            this.description = name;
            this.outcomeOdds = oddsList;
        }

        */
    }
}
