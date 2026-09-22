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
        int hours = 0, minutes = 0, seconds = 0;

        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var part in parts)
        {
            if (part.EndsWith("h"))
                int.TryParse(part.TrimEnd('h'), out hours);
            else if (part.EndsWith("m"))
                int.TryParse(part.TrimEnd('m'), out minutes);
            else if (part.EndsWith("s"))
                int.TryParse(part.TrimEnd('s'), out seconds);
        }
        return hours * 3600 + minutes * 60 + seconds;
    }

    static string FormatTime(int totalSeconds)
    {
        int h = totalSeconds / 3600;
        int m = (totalSeconds % 3600) / 60;
        int s = totalSeconds % 60;

        if (h > 0)
            return $"{h}h {m}m {s}s";
        if (m > 0)
            return $"{m}m {s}s";
        return $"{s}s";

    }
}