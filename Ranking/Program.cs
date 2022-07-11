using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPass = new Dictionary<string, string>();

            string command;
            while ((command = Console.ReadLine()) != "end of contests")
            {
                string contest = command.Split(':')[0];
                string pass = command.Split(':')[1];

                contestPass.Add(contest, pass);
            }

            SortedDictionary<string, Dictionary<string, int>> nameContestPoints = new SortedDictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string contest = input.Split("=>")[0];
                string pass = input.Split("=>")[1];
                string username = input.Split("=>")[2];
                int points = int.Parse(input.Split("=>")[3]);

                if (contestPass.ContainsKey(contest))
                {
                    if (contestPass[contest] == pass)
                    {
                        if (nameContestPoints.ContainsKey(username))
                        {
                            if (nameContestPoints[username].ContainsKey(contest))
                            {
                                if (nameContestPoints[username][contest] < points)
                                {
                                    nameContestPoints[username][contest] = points;
                                }
                            }
                            else
                            {
                                nameContestPoints[username].Add(contest, points);
                            }
                        }
                        else
                        {
                            nameContestPoints.Add(username, new Dictionary<string, int>());
                            nameContestPoints[username].Add(contest, points);
                        }
                    }
                }
            }

            int bestPoints = int.MinValue;
            string bestUser = "";
            foreach (var userPair in nameContestPoints)
            {
                int currentUserPoints = 0;
                foreach (var contestPair in userPair.Value)
                {
                    currentUserPoints += contestPair.Value;
                }

                if (currentUserPoints > bestPoints)
                {
                    bestPoints = currentUserPoints;
                    bestUser = userPair.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestUser} with total {bestPoints} points.");

            

            //foreach (var nameDictPair in nameContestPoints)
            //{
            //    Console.WriteLine(nameDictPair.Key);

            //    foreach (var item in nameDictPair.Value.OrderByDescending(item => item.Value))
            //    {

            //    }

            //    //nameDictPair.Value.OrderByDescending(x => x.Value);
            //    //foreach (var contPoDict in nameDictPair.Value.OrderByDescending(x => x.Value))
            //    //{
            //    //    Console.WriteLine();
            //    //}

            //}

            //nameContestPoints.Values.OrderByDescending(x => x.Values);

        }
    }
}
