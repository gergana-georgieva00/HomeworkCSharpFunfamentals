﻿using System;

namespace Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string result = string.Empty;

            if (age >= 0 && age <= 2)
            {
                result = "baby";
            }
            else if (age >= 3 && age <= 13)
            {
                result = "child";
            }
            else if (age >= 14 && age <= 19)
            {
                result = "teenager";
            }
            else if (age >= 20 && age <= 65)
            {
                result = "adult";
            }
            else
            {
                result = "elder";
            }

            Console.WriteLine(result);
        }
    }
}
