using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Events.WebApplication;
using Events.Model;
using Events.WebApplication.GenerateMatches;
using System.Web.Http;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.Http.Cors;
using System.Text;
using WebService.GenerateMatches;
using Newtonsoft.Json.Linq;

namespace WebService.Controllers
{
    public class GenerateFixtureController : ApiController
    {

        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        //public IHttpActionResult GetMatches()
        //{
            
        //    var teams = new Dictionary<Team, int>();
        //    List<Team> teamList = new List<Team>();
        //    for (int i = 0; i < 16; i++)
        //    {
        //        Team t1 = new Team
        //        {
        //            TeamId = i + 1,
        //            Name = "Team " + (i + 1),
        //        };
        //        teamList.Add(t1);
        //    }

        //    for (int i = 0; i < teamList.Count; i++)
        //    {
        //        teams.Add(teamList[i], i + 1);
        //    }

        //    for (int i = 4; i < 100; i+=2)
        //    {
        //        int numberOfUrns = MatchGenerator.GetNumberOfUrns(i);
        //    }
            
        //    var allMatches = MatchGenerator.GenerateRandomKnockoutMatches(teamList);

        //    var fixture = new List<Fixture>();
        //    foreach (var round in allMatches)
        //    {

        //        foreach (var match in round)
        //        {
        //            var game = match.Key.HomeTeam.Name + " vs " + match.Key.GuestTeam.Name;
        //            var rnd = round.FirstOrDefault().Value;
        //            fixture.Add(new Fixture()
        //            {
        //                Game = game,
        //                Round = rnd
        //            });                 
        //        }
        //    }
        
        //    return Json(fixture);
        //}

    
        [System.Web.Http.HttpGet]
        public IHttpActionResult GroupStages()
        {
            var teams = new Dictionary<Team, int>();
            List<Team> teamList = new List<Team>();
            for (int i = 0; i < 16; i++)
            {
                Team t1 = new Team
                {
                    TeamId = i + 1,
                    Name = "Team " + (i + 1),
                };
                teamList.Add(t1);
            }

            for (int i = 0; i < teamList.Count; i++)
            {
                teams.Add(teamList[i], i + 1);
            }

          
                int numberOfUrns = MatchGenerator.GetNumberOfUrns(teams.Keys.Count);
            var groups = MatchGenerator.GroupStages(teams, numberOfUrns);
            var groupGames = new List<List<Dictionary<Game, int>>>();
            foreach (var group in groups)
            {
                var games = MatchGenerator.GroupStageMatches(group);
                groupGames.Add(games);
            }
            
            return Ok();
        }

    }
}
