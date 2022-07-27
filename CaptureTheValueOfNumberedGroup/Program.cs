using System;
using System.Text.RegularExpressions;

namespace CaptureTheValueOfNumberedGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "<b>Regular Expressions</b> <p>I am a paragraph</p> ... some text after <span>Hello, I am Span</span> <a href=\"https://softuni.bg/\">SoftUni>/a>";

            Regex regex = new Regex(@"<(.+)[^>]*>(.*?)<\/\1>");
            MatchCollection matches = regex.Matches(text);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
