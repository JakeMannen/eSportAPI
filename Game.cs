using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eSport
{
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
        /*
        public Game(string homeTeam, string awayTeam, string venue, DateTime startDate)
        {
         
            this.homeTeam = homeTeam;
            this.awayTeam = awayTeam;
            this.venue = venue;
            this.startDate = startDate;
            this.description = homeTeam + " facing " + awayTeam + " at " + venue + " starting at " + startDate;
        }

        public Game(string description, string homeTeam, string awayTeam, string venue, DateTime startDate, List<GameType> gameTypes)
        {

            this.homeTeam = homeTeam;
            this.awayTeam = awayTeam;
            this.venue = venue;
            this.startDate = startDate;
            this.description = description;
        }
        */
    }
}
