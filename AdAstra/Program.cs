using System;
using System.Threading;

namespace AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintInParallel();  
        } 

        private static void PrintInParallel()
        {
            var newThread = new Thread(() => 
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write("x");
                }
            });

            newThread.Start();

            for (int i = 0; i < 1000; i++)
            {
                Console.Write("y");
            }

            // When doing work on two threads the reasult is undeterministic
            // we can't know which task is going to be done first
            // in the example we can see in the console that both are printing in the same time
            // the cpu is giving a little time to each thread and thats why we see chunks of x and chunks of y iterating one after
            // another, but that is not in our controll, we can not say for cirtain which one will start printing first, or if one isn't going 
            // to finish before the other. 
        }
    }
}
