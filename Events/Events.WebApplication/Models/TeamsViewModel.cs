namespace Events.WebApplication.Models
{
    using Model;
    using System.Collections.Generic;

    public class TeamsViewModel
    {
        public int TeamViewModelId { get; set; }
        public string Name { get; set; }

        public List<Player> Members { get; set; }
    }
}