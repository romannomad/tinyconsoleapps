using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.Title = "Console Timer";

        Console.WriteLine("Enter time (examples: 1h 20m 30s, 45m, 120s):");
        Console.Write("Time:");
        string input = Console.ReadLine()?.Trim().ToLower();
        int totalSeconds = ParseTime(input);

        if (!int.TryParse(Console.ReadLine(), out int seconds) || seconds <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid number.");
            Console.ResetColor();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Timer started...");
        Console.WriteLine();

        for (int i = seconds; i >= 0; i--)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Time left: {i} seconds   ");
            Console.ResetColor();

            Thread.Sleep(1000);

            Console.Write("\r");
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Time's up!");
        Console.ResetColor();

    }

    static int ParseTime(string input)
    {

    }
}