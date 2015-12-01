using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Events.Model;
using System.Text;
namespace Events.WebApplication.GenerateMatches
{
    public class MatchGenerator
    {
        private static IList<Team[]> matches = new List<Team[]>();
        public static List<Dictionary<Game, int>> GenerateMatches (IDictionary<Team,int> teamRanks, int numberOfUrns)
        {
            int rounds = CalcNumberOfRounds(teamRanks.Count);
            List<Dictionary<Game, int>> allMatches = new List<Dictionary<Game, int>>();
            for (int round = 1; round < rounds; round++)
            {
                var urns = new List<Team[]>();
                if (round == 1)
                {
                    urns = GenerateUrns(teamRanks, numberOfUrns);
                    var matchList = new Dictionary<Game, int>();
                    var otherMatchList = new Dictionary<Game, int>();

                    matchList = GenerateGames(round, urns, matchList, true);
                    var other = GenerateGames(round, urns, otherMatchList, false);

                    var merged = MergeMatches(matchList, otherMatchList);
                    allMatches.Add(merged);
                }
                allMatches.Add( NextRound(allMatches.Last(),round+1));
            }
            return allMatches;
        }

        private static Dictionary<Game, int> NextRound(Dictionary<Game, int> lastRound,int round)
        {
            Dictionary<Game, int> nextRound = new Dictionary<Game, int>();
            List<Team> allGames = new List<Team>();
            foreach (var game in lastRound)
            {
                var winner = new Team { Name = "<Winner of "+game.Key.HomeTeam.Name + " vs " + game.Key.GuestTeam.Name+" >" };
                allGames.Add(winner);
            }

            for (int i = 0; i < allGames.Count-1; i+=2)
            {
                var teams =  new Team[2];
                teams[0] = allGames[i];
                teams[1] = allGames[i + 1];
                var match = new Game(teams[0], teams[1]);
                            
                nextRound.Add(match,round);
            }

           return nextRound;
        }

        private static Dictionary<Game, int> MergeMatches
            (Dictionary<Game, int> matchList1, Dictionary<Game, int> matchList2)
        {
            var merged = new Dictionary<Game, int>();
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
                        merged.Add(new Game(match.Key.HomeTeam, otherMatch.Key.GuestTeam), match.Value);
                    }
                    team2Index++;
                }
                team1Index++;
            }

            return merged;
        }


        private static Dictionary<Game, int>  GenerateGames
            (int rounds,List<Team[]> urns,  Dictionary<Game, int> matchList, bool forEvens)
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
                                matchList.Add(new Game(null,homeTeam), i);
                            }
                           else
                            {
                                matchList.Add(new Game(homeTeam), i);
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
                Random rnd = new Random();
                Team[] shuffledTeams = teams.OrderBy(x => rnd.Next()).ToArray();
                urns.Add(shuffledTeams);
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