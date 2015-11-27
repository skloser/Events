namespace Events.WebApplication.Models
{
    using System;
    using System.Collections.Generic;

    public class MyMatchStatisticsViewModel
    {
        public string MyTeamName { get; set; }

        public IEnumerable<string>  Opponents { get; set; }

        public int? MyResult { get; set; }

        public int? OpponentResult { get; set; }

        public DateTime TimePlayed { get; set; }
    }
}
