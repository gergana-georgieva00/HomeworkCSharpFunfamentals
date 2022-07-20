using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contestsAndTheirUsers = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> individualStatistics = new Dictionary<string, int>();

            string input;
            while ((input = Console.ReadLine()) != "no more time")
            {
                string username = input.Split(" -> ")[0];
                string contest = input.Split(" -> ")[1];
                int points = int.Parse(input.Split(" -> ")[2]);

                //
                if (!individualStatistics.ContainsKey(username))
                {
                    individualStatistics.Add(username, points);
                }
                
                //

                if (contestsAndTheirUsers.ContainsKey(contest))
                {
                    if (individualStatistics[username] < points && contestsAndTheirUsers[contest].ContainsKey(username))
                    {
                        individualStatistics[username] = points;
                    }

                    if (contestsAndTheirUsers[contest].ContainsKey(username))
                    {
                        if (contestsAndTheirUsers[contest][username] < points)
                        {
                            contestsAndTheirUsers[contest][username] = points;

                            if (!contestsAndTheirUsers.ContainsKey(contest))
                            {
                                individualStatistics[username] += points;
                            }
                            else
                            {
                               // individualStatistics[username] = points;
                            }
                        }
                    }
                    else
                    {
                        contestsAndTheirUsers[contest].Add(username, points);

                        if (!individualStatistics.ContainsKey(username))
                        {
                            individualStatistics[username] += points;
                        }
                    }
                }
                else
                {
                    contestsAndTheirUsers.Add(contest, new Dictionary<string, int>());
                    contestsAndTheirUsers[contest].Add(username, points);

                    if (individualStatistics.ContainsKey(username))
                    {
                        individualStatistics[username] += points;
                    }
                }

                
            }

            // print each contest in order of input,

            // for each contest print the participants ordered by points in descending order,
            // then ordered by name in ascending order.

            // After that, you should print individual statistics for every participant,
            // ordered by total points in descending order,
            // and then by alphabetical order

            foreach (var contestPair in contestsAndTheirUsers)
            {
                Console.WriteLine($"{contestPair.Key}: {contestPair.Value.Count} participants");

                int counter = 1;
                foreach (var usernamePair in contestPair.Value.Keys
                    .Select(x => new { Username = x, Points = contestPair.Value[x] })
                    .OrderByDescending(x => x.Points)
                    .ThenBy(x => x.Username)
                    .ToList())
                {
                    Console.WriteLine($"{counter}. {usernamePair.Username} <::> {usernamePair.Points}");
                    counter++;
                }
            }

            
            Console.WriteLine("Individual standings:");

        }
    }
}
