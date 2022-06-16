using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string output = "";

                if (command.Contains("exchange"))
                {
                    string[] splitCommand = command.Split(' ').ToArray();
                    int index = int.Parse(splitCommand[1]);

                    if (index > input.Length - 1 || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    else
                    {
                        List<int> partOne = new List<int>();
                        List<int> partTwo = new List<int>();
                        int[] newExchangedArray = new int[input.Length];

                        for (int i = 0; i <= index; i++)
                        {
                            partTwo.Add(input[i]);
                        }

                        for (int i = index + 1; i < input.Length; i++)
                        {
                            partOne.Add(input[i]);
                        }

                        List<int> connected = new List<int>();
                        foreach (var item in partOne)
                        {
                            connected.Add(item);
                        }

                        foreach (var item in partTwo)
                        {
                            connected.Add(item);
                        }

                        newExchangedArray = connected.ToArray();
                        input = newExchangedArray;
                    }
                }
                else if (command.Contains("max"))
                {
                    output = MaxEvenOrOdd(input, command);
                    Console.WriteLine(output);
                }
                else if (command.Contains("min"))
                {
                    output = MinEvenOrOdd(input, command);
                    Console.WriteLine(output);
                }
                else if (command.Contains("first"))
                {
                    output = FirstEvenOrOdd(input, command);
                    Console.WriteLine(output);
                }
                else if (command.Contains("last"))
                {
                    output = LastEvenOrOdd(input, command);
                    Console.WriteLine(output);
                }
            }

            Console.WriteLine($"[{string.Join(", ", input)}]");
        }

        static string MaxEvenOrOdd(int[] array, string command)
        {
            int max = int.MinValue;
            int indexMax = -1;
            string output = "";

            // max even
            if (command.Contains("even"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && array[i] >= max)
                    {
                        max = array[i];
                        indexMax = i;
                    }
                }
            }
            // max odd
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (!(array[i] % 2 == 0) && array[i] >= max)
                    {
                        max = array[i];
                        indexMax = i;
                    }
                }
            }

            if (indexMax == -1)
            {
                output = "No matches";
            }
            else
            {
                output = indexMax.ToString();
            }

            return output;
        }

        static string MinEvenOrOdd(int[] array, string command)
        {
            int min = int.MaxValue;
            int indexMin = -1;
            string output = "";

            // max even
            if (command.Contains("even"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && array[i] <= min)
                    {
                        min = array[i];
                        indexMin = i;
                    }
                }
            }
            // max odd
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (!(array[i] % 2 == 0) && array[i] <= min)
                    {
                        min = array[i];
                        indexMin = i;
                    }
                }
            }

            if (indexMin == -1)
            {
                output = "No matches";
            }
            else
            {
                output = indexMin.ToString();
            }

            return output;
        }

        static string FirstEvenOrOdd(int[] array, string command)
        {
            string[] splitCommand = command.Split(' ').ToArray();
            int count = int.Parse(splitCommand[1]);
            string output;

            if (count > array.Length)
            {
                output = "Invalid count";
            }
            else
            {
                int counter = 0;
                List<int> firstEvenOrOdd = new List<int>();
                // first even
                if (command.Contains("even"))
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 == 0)
                        {
                            firstEvenOrOdd.Add(array[i]);
                            counter++;
                        }

                        if (counter == count)
                        {
                            break;
                        }
                    }
                }
                // first odd
                else
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (!(array[i] % 2 == 0))
                        {
                            firstEvenOrOdd.Add(array[i]);
                            counter++;
                        }

                        if (counter == count)
                        {
                            break;
                        }
                    }
                }

                int[] elements = firstEvenOrOdd.ToArray();
                output = string.Format($"[{string.Join(", ", elements)}]");
            }

            return output;
        }

        static string LastEvenOrOdd(int[] array, string command)
        {
            string[] splitCommand = command.Split(' ').ToArray();
            int count = int.Parse(splitCommand[1]);
            string output;

            if (count > array.Length)
            {
                output = "Invalid count";
            }
            else
            {
                int counter = 0;
                List<int> lastEvenOrOdd = new List<int>();
                // last even
                if (command.Contains("even"))
                {
                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        if (array[i] % 2 == 0)
                        {
                            lastEvenOrOdd.Add(array[i]);
                            counter++;
                        }

                        if (counter == count)
                        {
                            break;
                        }
                    }
                }
                // last odd
                else
                {
                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        if (!(array[i] % 2 == 0))
                        {
                            lastEvenOrOdd.Add(array[i]);
                            counter++;
                        }

                        if (counter == count)
                        {
                            break;
                        }
                    }
                }

                lastEvenOrOdd.Reverse();
                output = string.Format($"[{string.Join(", ", lastEvenOrOdd)}]");
            }

            return output;
        }
    }
}
