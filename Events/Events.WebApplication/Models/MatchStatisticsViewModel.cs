namespace Events.WebApplication.Models
{
    using System;

    public class MatchStatisticsViewModel
    {
        public string HomeTeamName { get; set; }

        public string GuestTeamName { get; set; }

        public int? HomeTeamResult { get; set; }

        public int? GuestTeamResult { get; set; }

        public DateTime TimeOfMatch { get; set; }
    }
}

