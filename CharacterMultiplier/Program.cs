using System;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Console.WriteLine(GetCharacterSum(input[0], input[1]));
        }

        static int GetCharacterSum(string str1, string str2)
        {
            int sum = 0;

            // equal lengths
            if (str1.Length == str2.Length)
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    sum += str1[i] * str2[i];
                }
            }
            // diff lengths
            else
            {
                int remainingLength = 0;
                int start = 0;
                string longer = "";
                string shorter = "";
                
                if (str1.Length < str2.Length)
                {
                    longer = str2;
                    shorter = str1;
                }
                else
                {
                    longer = str1;
                    shorter = str2;
                }

                for (int i = 0; i < shorter.Length; i++)
                {
                    sum += (char)str1[i] * (char)str2[i];
                }

                for (int i = shorter.Length; i < longer.Length; i++)
                {
                    sum += (char)longer[i];
                }
            }

            return sum;
        }
    }
}
