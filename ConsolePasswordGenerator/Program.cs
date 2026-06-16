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

    }
}
