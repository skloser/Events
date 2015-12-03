namespace Events.WebApplication.Models
{
    using Events.Model;
    using System.Collections.Generic;

    public class MyTeamsViewModel
    {
        public int MyTeamViewId { get; set; }

        public string Name { get; set; }

        public List<Player> Members { get; set; }
    }
}