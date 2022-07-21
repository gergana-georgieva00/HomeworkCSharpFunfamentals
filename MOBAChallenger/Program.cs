using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playerPositionSkill = new Dictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "Season end")
            {
                if (!input.Contains("vs"))
                {
                    string[] splitPlayer = input.Split(" -> ");
                    string player = splitPlayer[0];
                    string position = splitPlayer[1];
                    int skill = int.Parse(splitPlayer[2]);

                    if (!playerPositionSkill.ContainsKey(player))
                    {
                        playerPositionSkill.Add(player, new Dictionary<string, int>());
                        playerPositionSkill[player].Add(position, skill);
                    }
                    else
                    {
                        if (!playerPositionSkill[player].ContainsKey(position))
                        {
                            playerPositionSkill[player].Add(position, skill);
                        }
                        else
                        {
                            if (playerPositionSkill[player][position] < skill)
                            {
                                playerPositionSkill[player][position] = skill;
                            }
                        }
                    }
                }
                // player vs player
                else
                {
                    string[] playerVsPlayer = input.Split(" vs ");
                    string player1 = playerVsPlayer[0];
                    string player2 = playerVsPlayer[1];

                    // check if the players exist
                    if (playerPositionSkill.ContainsKey(player1) && playerPositionSkill.ContainsKey(player2))
                    {
                        // check if both have common position
                        bool haveCommonPositon = false;
                        string commonPositon = "";

                        foreach (var pl1Pair in playerPositionSkill[player1])
                        {
                            string currPosition = pl1Pair.Key;

                            if (playerPositionSkill[player2].ContainsKey(currPosition))
                            {
                                haveCommonPositon = true;
                                commonPositon = currPosition;
                            }
                        }

                        if (haveCommonPositon)
                        {
                            int points1 = 0;
                            int points2 = 0;

                            foreach (var item in playerPositionSkill[player1])
                            {
                                points1 += item.Value;
                            }

                            foreach (var item in playerPositionSkill[player2])
                            {
                                points2 += item.Value;
                            }

                            if (points1 != points2)
                            {
                                if (points1 > points2)
                                {
                                    playerPositionSkill.Remove(player2);
                                }
                                else
                                {
                                    playerPositionSkill.Remove(player1);
                                }
                            }
                        }
                    }
                }
            }

            // print the players, ordered by total skill in descending order,
            // then ordered by player name in ascending order.
             
            // Foreach player print their position and skill, ordered descending by skill,
            // then ordered by position name in ascending order.


            Dictionary<string, int> playerPoints = new Dictionary<string, int>();

            foreach (var playerDic in playerPositionSkill)
            {
                foreach (var positionSkill in playerDic.Value)
                {
                    if (playerPoints.ContainsKey(playerDic.Key))
                    {
                        playerPoints[playerDic.Key] += positionSkill.Value;
                    }
                    else
                    {
                        playerPoints.Add(playerDic.Key, positionSkill.Value);
                    }
                }
            }

            // print
            foreach (var item in playerPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} skill");

                foreach (var playerDic in playerPositionSkill[item.Key].OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {playerDic.Key} <::> {playerDic.Value}");
                }
            }
        }
    }
}
