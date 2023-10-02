using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace PrimeNumbersAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, prime;
            Stopwatch timer = new Stopwatch();

            PrintBanner();
            n = GetNumber();

            timer.Start();
            prime = FindNthPrime(n);
            timer.Stop();
            
            
            Console.WriteLine($"\nToo easy.. {prime} is the nth prime when n is {n}. I found that answer in {timer.Elapsed.Seconds} s.");

            EvaluatePassingTime(timer.Elapsed.Seconds);
        }

        static int FindNthPrime(int n)
        {
            int i;
            int count = 2;

            if (n == 1) return 2;

            for (i = 3; i < int.MaxValue; i+=2)
            {
                int sqrt = (int)Math.Sqrt(i) + 1;
                for (int j = 3; j <= sqrt; j+=2)
                {
                    if (i % j == 0)
                    {
                        break;
                    }
                    if (j >= sqrt - 1)
                    {
                        count++;
                        break;
                    }
                }
                if (count == n)
                {
                    break;
                }
            }
            return i;
        }

        static int GetNumber()
        {
            int n = 0;
            while (true)
            {
                Console.Write("Which nth prime should I find?: ");
                
                string num = Console.ReadLine();
                if (Int32.TryParse(num, out n))
                {
                    return n;
                }

                Console.WriteLine($"{num} is not a valid number.  Please try again.\n");
            }
        }

        static void PrintBanner()
        {
            Console.WriteLine(".................................................");
            Console.WriteLine(".#####...#####...######..##...##..######...####..");
            Console.WriteLine(".##..##..##..##....##....###.###..##......##.....");
            Console.WriteLine(".#####...#####.....##....##.#.##..####.....####..");
            Console.WriteLine(".##......##..##....##....##...##..##..........##.");
            Console.WriteLine(".##......##..##..######..##...##..######...####..");
            Console.WriteLine(".................................................\n\n");
            Console.WriteLine("Nth Prime Solver O-Matic Online..\nGuaranteed to find primes up to 2 million in under 30 seconds!\n\n");
            
        }

        static void EvaluatePassingTime(int time)
        {
            Console.WriteLine("\n");
            Console.Write("Time Check: ");

            if (time <= 10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pass");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            
        }
    }
}
