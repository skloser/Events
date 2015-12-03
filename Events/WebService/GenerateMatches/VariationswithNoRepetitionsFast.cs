using Events.Model;
using System;
using System.Collections.Generic;

class VariationsNoRepetitionsFast
{
    const int k = 6;
    const int n = 4;
    private static Team[] arr = new Team[k];
    private static List<Team[]> games = new List<Team[]>();
    public static List<Team[]> GetVariations(Team[] teams)
    {
        
        GenerateVariationsNoRepetitions(0,teams);

        return games;
    }

    static void GenerateVariationsNoRepetitions(int index, Team[] free)
    {
        if (index >= k)
        {
            games.Add(arr);
        }
        else
        {
            for (int i = index; i < n; i++)
            {
                arr[index] = free[i];
                Swap(ref free[i], ref free[index]);
                GenerateVariationsNoRepetitions(index + 1,free);
                Swap(ref free[i], ref free[index]);
            }
        }
    }

    private static void Swap(ref Team v1, ref Team v2)
    {
        Team old = v1;
        v1 = v2;
        v2 = old;
    }

   
}
