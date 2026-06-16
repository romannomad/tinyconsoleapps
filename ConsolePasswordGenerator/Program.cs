using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Password Generator ===");

        int length = AskInt("Password length (e.g. 12): ");
        bool includeNumbers = AskBool("Include numbers (y/n): ");
        bool includeSymbols = AskBool("Include symbols (y/n): ");
        bool includeUpper = AskBool("Include uppercase letters (y/n): ");
        bool includeLower = AskBool("Include lowercase letters (y/n): ");

        string password = GeneratePassword(length, includeNumbers, includeSymbols, includeUpper, includeLower);
        Console.WriteLine($"\nGenerated password: {password}");

    }
    static int AskInt(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine()!);
    }

    static bool AskBool(string message)
    {
        Console.Write(message);
        string input = Console.ReadLine()!.Trim().ToLower();
        return input == "y" || input == "yes";
    }

    static string GeneratePassword(int length, bool numbers, bool symbols, bool upper, bool lower)
    {
        string digits = "0123456789";
        string specialChars = "!@#$%^&*()_-+=<>?";
        string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string lowerChars = "abcdefghijklmnopqrstuvwxyz";

        StringBuilder pool = new();

        if (numbers) pool.Append(digits);
        if (symbols) pool.Append(specialChars);
        if (upper) pool.Append(upperChars);
        if (lower) pool.Append(lowerChars);

        if (pool.Length == 0)
        {
            throw new Exception("At least one character type must be included.");
        }

        StringBuilder password = new();
        using var rng = RandomNumberGenerator.Create();

        for (int i = 0; i < length; i++)
        {
            byte[] randomByte = new byte[1];


        }

    }
}
