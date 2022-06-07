using System;
using System.Collections.Generic;
using System.Linq;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            string sequence;

            List<Sequence> sequences = new List<Sequence>();
            int counter = 0;
            while ((sequence = Console.ReadLine()) != "Clone them!")
            {
                int bestIndex = int.MaxValue;
                int bestSum = 0;
                int bestLength = 0;
                List<int> currenctCollection = sequence.Split('!').Select(int.Parse).ToList();
                counter++;
                List<int> bestArrToList = new List<int>();

                // check each array's element and collect only the 1's
                int currSum = 0;
                int currLength = 0;
                int currStartingIndex = 0;

                for (int i = 0; i < currenctCollection.Count(); i++)
                {
                    int currElement = currenctCollection[i];
                    int index = i;

                    // sum the elements in the current array
                    if (currElement == 1)
                    {
                        currSum++;
                        currLength++;
                        
                        //find the current best starting index
                        if (currLength == 1)
                        {
                            currStartingIndex = index;
                        }

                        // find the best lenght
                        if (currLength > bestLength)
                        {
                            bestLength = currLength;
                            bestIndex = currStartingIndex;
                        }
                    }
                    else
                    {
                        currLength = 0;
                    }
                }

                bool sequenceHasAny = sequences.Any();
                if (!sequenceHasAny)
                {
                    Sequence currentSequence = new Sequence(bestIndex, counter, bestLength, currenctCollection);
                }
                else
                {
                    Sequence firstSequence = sequences[0];
                    bool deleteOldSequences = true;
                    bool addCurrentSequence = false;
                    if (firstSequence.BestLength < bestLength)
                    {
                        addCurrentSequence = true;
                    }
                    else if(firstSequence.BestLength == bestLength)
                    {
                        if (firstSequence.StartingIndex < bestIndex)
                        {
                            addCurrentSequence = true;
                        } 
                        else if (firstSequence.StartingIndex == bestIndex)
                        {
                            int firstSequenceSum = firstSequence.Collection.Sum();
                            int currentSequenceSum = currenctCollection.Sum();
                            if (firstSequenceSum < currentSequenceSum)
                            {
                                addCurrentSequence = true;
                            }
                            else if (firstSequenceSum == currentSequenceSum)
                            {
                                addCurrentSequence = true;
                                deleteOldSequences = false;
                            };
                        }
                    }

                    if (addCurrentSequence)
                    {
                        if (deleteOldSequences)
                        {
                            sequences = new List<Sequence>();
                        }

                        Sequence currentSequence = new Sequence(bestIndex, counter, bestLength, currenctCollection);
                        sequences.Add(currentSequence);
                    }
                }

                // find the best array and save it in a list
                //if (currStartingIndex < bestIndex)
                //{
                //    bestArrToList = new List<int>(arr.ToList());
                //}
                //else if (currStartingIndex == bestIndex)
                //{
                //    if (currSum > bestSum)
                //    {
                //        bestArrToList = new List<int>(arr.ToList());
                //    }
                //}


                // find the best sum
                //if (currSum > bestSum)
                //{
                //    bestSum = currSum;
                //}



            }
        }
    }

    internal class Sequence
    {
        private int startingIndex;
        private int counter;
        private int bestLength;
        private List<int> sequence;

        public Sequence(int startingIndex, int counter, int bestLength, List<int> sequence)
        {
            this.Collection = new List<int>(sequence);
            this.StartingIndex = startingIndex;
            this.Counter = counter;
            this.BestLength = bestLength;
        }

        public int BestLength
        {
            get { return bestLength; }
            set { bestLength = value; }
        }

        public List<int> Collection
        {
            get { return sequence; }
            set { sequence = value; }
        }


        public int Counter
        {
            get { return counter; }
            set { counter = value; }
        }


        public int StartingIndex
        {
            get { return startingIndex; }
            set { startingIndex = value; }
        }

    }
}
