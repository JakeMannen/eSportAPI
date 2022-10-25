using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eSport
{
    //The GameType data model
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

    }
}
