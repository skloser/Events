using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Events.Model;
using System.Text;
using Events.Model.Statistics;
namespace Events.WebApplication.GenerateMatches
{
    public class MatchGenerator
    {
        private static IList<Team[]> matches = new List<Team[]>();
        public static List<Dictionary<Match, int>> GenerateMatches (IDictionary<Team,int> teamRanks, int numberOfUrns)
        {
            int rounds = CalcNumberOfRounds(teamRanks.Count);
            List<Dictionary<Match,int>> allMatches = new List<Dictionary<Match, int>>();
            for (int round = 1; round < rounds; round++)
            {
                var urns = new List<Team[]>();
                if (round == 1)
                {
                    urns = GenerateUrns(teamRanks, numberOfUrns);
                    var matchList = new Dictionary<Match, int>();
                    var otherMatchList = new Dictionary<Match, int>();

                    matchList = GenerateGames(round, urns, matchList, true);
                    var other = GenerateGames(round, urns, otherMatchList, false);

                    var merged = MergeMatches(matchList, otherMatchList);
                    allMatches.Add(merged);
                }
                allMatches.Add( NextRound(allMatches.Last(),round+1));
            }
            return allMatches;
        }

        private static Dictionary<Match, int> NextRound(Dictionary<Match, int> lastRound,int round)
        {
            Dictionary<Match, int> nextRound = new Dictionary<Match, int>();
            List<Team> allGames = new List<Team>();
            foreach (var game in lastRound)
            {
                var winner = new Team { Name = "[Winner of {"+game.Key.HomeTeam.Name + " vs " + game.Key.GuestTeam.Name+"} ]" };
                allGames.Add(winner);
            }

            for (int i = 0; i < allGames.Count-1; i+=2)
            {
                var teams =  new Team[2];
                teams[0] = allGames[i];
                teams[1] = allGames[i + 1];
                var match = new Match(teams[0], teams[1]);
                            
                nextRound.Add(match,round);
            }

           return nextRound;
        }

        private static Dictionary<Match, int> MergeMatches
            (Dictionary<Match, int> matchList1, Dictionary<Match, int> matchList2)
        {
            var merged = new Dictionary<Match, int>();
            int team1Index = 0;
            foreach (var match in matchList1)
            {
                int team2Index = 0;
                foreach (var otherMatch in matchList2.Reverse())
                {
                    if(team2Index>team1Index)
                    {
                        break;
                    }
                    if(team1Index==team2Index)
                    {
                        merged.Add(new Match(match.Key.HomeTeam, otherMatch.Key.GuestTeam), match.Value);
                    }
                    team2Index++;
                }
                team1Index++;
            }

            return merged;
        }


        private static Dictionary<Match, int>  GenerateGames
            (int rounds,List<Team[]> urns,  Dictionary<Match, int> matchList, bool forEvens)
        {
            int[] fractions = new int[9];
            if(!forEvens)
            {
                fractions = Enumerable.Range(1,9).ToArray();
            }
            var usedTeams = new HashSet<Team>();
            var usedUrns = new HashSet<Team[]>();
            for (int i = 1; i <= rounds; i++)
            {
                int urnIndex = 1;
                foreach (var urn in urns)
                {
                    if (usedUrns.Contains(urn))
                    {
                        continue;
                    }
                    if (fractions.Contains(urnIndex % 2) )
                    {
                        foreach (var team in urn)
                        {
                            if (usedTeams.Contains(team))
                            {
                                continue;
                            }
                            var homeTeam = new Team()
                            {
                                Name = team.Name
                            };
                            usedTeams.Add(homeTeam);
                            if (!forEvens)
                            {
                                matchList.Add(new Match(null,homeTeam), i);
                            }
                           else
                            {
                                matchList.Add(new Match(homeTeam), i);
                            }
                            
                        }
                    }
                    usedUrns.Add(urn);
                    urnIndex++;
                }
               
            }
                return matchList;
            
        }
        private static int CalcNumberOfRounds(int numberOfTeams,int rounds=0)
        {
            if(numberOfTeams==1)
            {
                return rounds;
            }
            else
            {
                return CalcNumberOfRounds(numberOfTeams / 2,rounds+1);
            }
        }

        private static List<Team[]> GenerateUrns(IDictionary<Team, int> teamRanks, int numberOfUrns)
        {
            var urns = new List<Team[]>();
            var sortedTeamRanks = teamRanks.OrderBy(team => team.Value);
            int numberOfTeams = GCD(teamRanks.Count, numberOfUrns);
            var usedTeams = new HashSet<Team>();
            while (urns.Count < numberOfUrns)
            {
                var teams = new Team[numberOfTeams];
                int index = 0;
                foreach (var team in sortedTeamRanks)
                {
                    if (teams.Count(x => x != null) == numberOfTeams)
                    {
                        break;
                    }
                    if (!usedTeams.Contains(team.Key) && teams.Count(x => x != null) < numberOfTeams)
                    {
                        teams[index] = team.Key;
                        index++;
                        usedTeams.Add(team.Key);
                    }
                }
                urns.Add(teams);
            }

            return urns;
        }

       private static int GCD(int a, int b)
        {
            int Remainder;
            int prev = 0;
            int originalA = a;
            while (b != 0)
            {
                Remainder = a % b;
                a = b;
                b = Remainder;
                prev = a;
            }
            if (a != originalA)
            {
                return a;
            }
            else
            {
                return prev;
            }
        }


       
    }
}