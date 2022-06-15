using System;
using System.Collections.Generic;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] passWord = Console.ReadLine().ToCharArray();

            List<string> output = IsValid(passWord);
            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }

        static List<string> IsValid(char[] passWord)
        {
            List<string> output = new List<string>();

            if (SixToTenCharacters(passWord) && OnlyLettersAndDigits(passWord) && AtLeastTwoDigits(passWord))
            {
                output.Add("Password is valid");
            }
            else
            {
                if (!SixToTenCharacters(passWord))
                {
                    output.Add("Password must be between 6 and 10 characters");
                }

                if (!OnlyLettersAndDigits(passWord))
                {
                    output.Add("Password must consist only of letters and digits");
                }

                if (!AtLeastTwoDigits(passWord))
                {
                    output.Add("Password must have at least 2 digits");
                }
            }

            return output;
        }

        static bool SixToTenCharacters(char[] passWord)
        {
            int charCount = passWord.Length;
            bool valid = false;

            if (6 <= charCount && charCount <= 10)
            {
                valid = true;
            }

            return valid;
        }

        static bool OnlyLettersAndDigits(char[] passWord)
        {
            bool valid = true;

            foreach (var item in passWord)
            {
                if (Char.IsLetterOrDigit(item) == false)
                {
                    valid = false;
                }
            }

            return valid;
        }

        static bool AtLeastTwoDigits(char[] passWord)
        {
            bool valid = false;
            int digitCounter = 0;

            foreach (var item in passWord)
            {
                if (Char.IsDigit(item) == true)
                {
                    digitCounter++;
                }
            }

            if (digitCounter >= 2)
            {
                valid = true;
            }

            return valid;
        }
    }
}
