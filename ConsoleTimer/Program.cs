using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.Title = "Console Timer";

        Console.Write("Enter seconds to count down: ");
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
        })

    }
}