using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Events.Model;
namespace Events.WebApplication.GenerateMatches
{
    public class Match
    {
        public int Id { get; set; }
        public Team HomeTeam { get; set; }
        public Team GuestTeam { get; set; }

        public Match(Team hometeam, Team guestTeam)
        {
            this.HomeTeam = hometeam;
            this.GuestTeam = guestTeam;
        }

        public Match(Team hometeam):this(hometeam,null)
        {

        }

        public override string ToString()
        {
            return String.Format("{0} vs {1}", this.HomeTeam, this.GuestTeam);
        }

    }
}