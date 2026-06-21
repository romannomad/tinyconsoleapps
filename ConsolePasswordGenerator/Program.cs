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
        string strength = CheckStrength(password);


        Console.WriteLine($"\nGenerated password: {password}");
        PrintStrengthColored(strength);
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
            rng.GetBytes(randomByte);
            int index = randomByte[0] % pool.Length;
            password.Append(pool[index]);

        }

        return password.ToString();
    }

    static int CalculateScore(string password)
    {
        int score = 0;

        if (password.Length >= 8) score++;
        if (password.Length >= 12) score++;
        if (password.Any(char.IsDigit)) score++;
        if (password.Any(char.IsUpper)) score++;
        if (password.Any(char.IsLower)) score++;
        if (password.Any(ch => "!@#$%^&*()_-+=<>?".Contains(ch))) score++;

        return score; //0-6

    }

    static string CheckStrength(string password)
    {
        int score = 0;
        if (password.Length >= 8) score++;
        if (password.Length >= 12) score++;
        if (password.Any(char.IsDigit)) score++;
        if (password.Any(char.IsUpper)) score++;
        if (password.Any(char.IsLower)) score++;
        if (password.Any(ch => "!@#$%^&*()_-+=<>?".Contains(ch))) score++;

        return score switch
        {
            <= 2 => "Weak",
            3 or 4 => "Medium",
            5 => "Strong",
            _ => "Very Strong"

        };

    }

    static void PrintStrengthColored(string strength)
    {
        switch (strength)
        {
            case "Weak":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case "Medium":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case "Strong":
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case "Very Strong":
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
        }

        Console.WriteLine($"Strength: {strength}");
        Console.ResetColor();

    }

    static void PrintStrengthBar(int score)
    {
        int max = 6;
        int filled = score;
        int empty = max - filled;
    }

}
