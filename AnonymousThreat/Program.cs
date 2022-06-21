using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();

            string command;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] splitCommand = command.Split(' ').ToArray();

                if (command.Contains("merge"))
                {
                    int startIndex = int.Parse(splitCommand[1]);

                    if (startIndex > input.Count - 1)
                    {
                        continue;
                    }

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    int endIndex = int.Parse(splitCommand[2]);
                    if (endIndex > input.Count - 1)
                    {
                        endIndex = input.Count - 1;
                    }

                    string merged = string.Empty;
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        merged += input[i];
                    }

                    input.RemoveRange(startIndex, endIndex - startIndex + 1);
                    input.Insert(startIndex, merged);
                }
                else
                {
                    int index = int.Parse(splitCommand[1]);
                    int partitions = int.Parse(splitCommand[2]);

                    string partToDivide = input[index];
                    input.RemoveAt(index);

                    
                    if (partToDivide.Length % partitions == 0)
                    {
                        int chunkSize = partToDivide.Length / partitions;
                        for (int i = 0; i < partToDivide.Length; i += chunkSize)
                        {
                            if (i + chunkSize > partToDivide.Length)
                            {
                                chunkSize = partToDivide.Length - i;
                            }

                            input.Insert(index, partToDivide.Substring(i, chunkSize));
                            index++;
                        }
                    }
                    else
                    {
                        int chunkSize = partToDivide.Length / partitions;
                        for (int i = 0; i < partToDivide.Length; i += chunkSize)
                        {
                            if (i + chunkSize >= partToDivide.Length - partitions)
                            {
                                chunkSize = partToDivide.Length - i;
                            }

                            input.Insert(index, partToDivide.Substring(i, chunkSize));
                            index++;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(' ', input));
        }
    }
}
