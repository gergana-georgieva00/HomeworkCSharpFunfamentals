using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine().Split(", ").ToList();

            string command;
            while ((command = Console.ReadLine()) != "course start")
            {
                string[] splitCommand = command.Split(':');
                string lessonTitle = splitCommand[1];

                if (command.Contains("Add"))
                {
                    if (!schedule.Contains(lessonTitle))
                    {
                        schedule.Add(lessonTitle);
                    }
                }
                else if (command.Contains("Insert"))
                {
                    int index = int.Parse(splitCommand[2]);
                    if (!schedule.Contains(lessonTitle))
                    {
                        // check for valid index
                        if (index >= 0 && index < schedule.Count)
                        {
                            schedule.Insert(index, lessonTitle);
                        }
                    }
                }
                else if (command.Contains("Remove"))
                {
                    if (schedule.Contains(lessonTitle))
                    {
                        schedule.Remove(lessonTitle);
                        if (schedule.Contains($"{lessonTitle}-Exercise"))
                        {
                            schedule.Remove($"{lessonTitle}-Exercise");
                        }
                    }
                }
                else if (command.Contains("Swap"))
                {
                    string lessonTitle1 = splitCommand[2];

                    if (schedule.IndexOf(lessonTitle) < schedule.IndexOf(lessonTitle1))
                    {
                        if (schedule.Contains(lessonTitle) && schedule.Contains(lessonTitle1))
                        {
                            string temp = schedule[schedule.IndexOf(lessonTitle1)];
                            schedule[schedule.IndexOf(lessonTitle1)] = schedule[schedule.IndexOf(lessonTitle)];
                            schedule[schedule.IndexOf(lessonTitle)] = temp;

                            if (schedule.Contains($"{lessonTitle}-Exercise"))
                            {
                                schedule.Remove($"{lessonTitle}-Exercise");
                                schedule.Insert(schedule.IndexOf(lessonTitle) + 1, $"{lessonTitle}-Exercise");
                            }

                            if (schedule.Contains($"{lessonTitle1}-Exercise"))
                            {
                                schedule.Remove($"{lessonTitle1}-Exercise");
                                schedule.Insert(schedule.IndexOf(lessonTitle1) + 1, $"{lessonTitle1}-Exercise");
                            }
                        }
                    }
                    else
                    {
                        if (schedule.Contains(lessonTitle) && schedule.Contains(lessonTitle1))
                        {
                            string temp = schedule[schedule.IndexOf(lessonTitle)];
                            schedule[schedule.IndexOf(lessonTitle)] = schedule[schedule.IndexOf(lessonTitle1)];
                            schedule[schedule.IndexOf(lessonTitle1)] = temp;

                            if (schedule.Contains($"{lessonTitle1}-Exercise"))
                            {
                                schedule.Remove($"{lessonTitle1}-Exercise");
                                schedule.Insert(schedule.IndexOf(lessonTitle1) + 1, $"{lessonTitle1}-Exercise");
                            }

                            if (schedule.Contains($"{lessonTitle1}-Exercise"))
                            {
                                schedule.Remove($"{lessonTitle1}-Exercise");
                                schedule.Insert(schedule.IndexOf(lessonTitle1) + 1, $"{lessonTitle1}-Exercise");
                            }
                        }
                    }
                }
                else
                {
                    if (schedule.Contains(lessonTitle))
                    {
                        if (!schedule.Contains($"{lessonTitle}-Exercise"))
                        {
                            schedule.Insert(schedule.IndexOf(lessonTitle) + 1, $"{lessonTitle}-Exercise");
                        }
                    }
                    else
                    {
                        schedule.Add(lessonTitle);
                        schedule.Add($"{lessonTitle}-Exercise");
                    }
                }
            }

            int indexOfItem = 1;
            foreach (var item in schedule)
            {
                Console.WriteLine($"{indexOfItem}.{item}");
                indexOfItem++;
            }
        }
    }
}
