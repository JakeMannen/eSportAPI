using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eSport
{
    //The Game data model
    public class Game
    {
        public int id { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public string homeTeam { get; set; }

        [Required]
        public string awayTeam { get; set; }

        [Required]
        public string venue { get; set; }

        [Required]
        public DateTime startDate { get; set; }

        

    public Game()
        {
        }
    }
}
