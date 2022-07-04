﻿using System;
using System.Collections.Generic;

namespace AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phrases = new List<string>
            {
                "Excellent product.", 
                "Such a great product.", 
                "I always use that product.", 
                "Best product of its category.", 
                "Exceptional product.", 
                "I can’t live without this product."
            };

            List<String> events = new List<string>
            {   "Now I feel good.", 
                "I have succeeded with this product.", 
                "Makes miracles. I am happy of the results!", 
                "I cannot believe but now I feel awesome.", 
                "Try it yourself, I am very satisfied.", 
                "I feel great!"
            };

            List<string> authors = new List<string>
            {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};

            List<string> cities = new List<string>
            {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

            int n = int.Parse(Console.ReadLine());

            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                int randomPhrase = random.Next(phrases.Count);
                int randomEvent = random.Next(events.Count);
                int randomAuthor = random.Next(authors.Count);
                int randomCity = random.Next(cities.Count);

                Console.WriteLine($"{phrases[randomPhrase]} {events[randomEvent]} {authors[randomAuthor]} – {cities[randomCity]}.");
            }
        }
    }
}
