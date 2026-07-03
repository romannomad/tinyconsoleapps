using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        int count = AskInt("How many passwords to generate: ");// Ask user for the number of passwords to generate
        Console.WriteLine("=== Password Generator ===");

        int length = AskInt("Password length (e.g. 12): ");// Ask user for the desired password length
        bool includeNumbers = AskBool("Include numbers (y/n): ");// Ask user for character types to include
        bool includeSymbols = AskBool("Include symbols (y/n): ");
        bool includeUpper = AskBool("Include uppercase letters (y/n): ");
        bool includeLower = AskBool("Include lowercase letters (y/n): "); // Ask user for character types to include


        for (int i = 1; i <= count; i++)
        {
            string password = GeneratePassword(length, includeNumbers, includeSymbols, includeUpper, includeLower);
            int score = CalculateScore(password); // Calculate the score of the generated password
            string strength = CheckStrength(password); // Check the strength of the generated password

            Console.WriteLine($"\nGenerated password: {password}"); // Display the generated password
            PrintStrengthColored(strength); // Display the strength of the password with color coding
            PrintStrengthBar(score);// Display a visual strength bar for the password
            PrintFeedback(password);// Display feedback for improvement
        }
    }
    static int AskInt(string message)
    {
        Console.Write(message); // Prompt the user with the provided message
        return int.Parse(Console.ReadLine()!); // Read the user input and parse it as an integer
    }

    static bool AskBool(string message)
    {
        Console.Write(message);
        string input = Console.ReadLine()!.Trim().ToLower(); // Read the user input, trim whitespace, and convert to lowercase
        return input == "y" || input == "yes"; // Return true if the input is "y" or "yes", otherwise return false
    }

    static string GeneratePassword(int length, bool numbers, bool symbols, bool upper, bool lower)
    {
        string digits = "0123456789"; // Define the character sets for password generation
        string specialChars = "!@#$%^&*()_-+=<>?"; // Define the character sets for password generation
        string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Define the character sets for password generation
        string lowerChars = "abcdefghijklmnopqrstuvwxyz"; // Define the character sets for password generation

        StringBuilder pool = new(); // Create a StringBuilder to hold the pool of characters to choose from

        if (numbers) pool.Append(digits);// Append digits to the pool if included
        if (symbols) pool.Append(specialChars); //Append special characters to the pool if included
        if (upper) pool.Append(upperChars); // Append uppercase letters to the pool if included
        if (lower) pool.Append(lowerChars); // Append lowercase letters to the pool if included

        if (pool.Length == 0)
        {
            throw new Exception("At least one character type must be included."); // Throw an exception if no character types are included
        }

        StringBuilder password = new();
        using var rng = RandomNumberGenerator.Create(); // Create a secure random number generator

        for (int i = 0; i < length; i++) // Generate a password of the specified length
        {
            byte[] randomByte = new byte[1]; // Create a byte array to hold a random byte
            rng.GetBytes(randomByte);
            int index = randomByte[0] % pool.Length; // Use the random byte to select a character from the pool
            password.Append(pool[index]); // Append the selected character to the password

        }

        return password.ToString();// Return the generated password as a string
    }

    static int CalculateScore(string password) // Calculate the score of the password based on various criteria
    {
        int score = 0;

        if (password.Length >= 8) score++;// Increment score if password length is at least 8 characters
        if (password.Length >= 12) score++;// Increment score if password length is at least 12 characters
        if (password.Any(char.IsDigit)) score++;// Increment score if password contains at least one digit
        if (password.Any(char.IsUpper)) score++;// Increment score if password contains at least one uppercase letter
        if (password.Any(char.IsLower)) score++;// Increment score if password contains at least one lowercase letter
        if (password.Any(ch => "!@#$%^&*()_-+=<>?".Contains(ch))) score++;// Increment score if password contains at least one special character

        return score; //0-6

    }

    static string CheckStrength(string password)
    {
        int score = 0;// Calculate the score of the password based on various criteria
        if (password.Length >= 8) score++;
        if (password.Length >= 12) score++;
        if (password.Any(char.IsDigit)) score++;
        if (password.Any(char.IsUpper)) score++;
        if (password.Any(char.IsLower)) score++;
        if (password.Any(ch => "!@#$%^&*()_-+=<>?".Contains(ch))) score++;

        return score switch
        {
            <= 2 => "Weak", // Return "Weak" if score is 2 or less
            3 or 4 => "Medium", // Return "Medium" if score is 3 or 4
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

        Console.Write("Strength Bar: [");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(new string('#', filled));

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(new string('-', empty));

        Console.ResetColor();
        Console.WriteLine("]");

    }

    static void PrintFeedback(string password)
    {
        Console.WriteLine("\nFeedback:");

        if (password.Length < 8)
            Console.WriteLine("- Increase length to at least 8 characters");

        if (password.Length < 12)
            Console.WriteLine("- For strong security, use 12+ characters");

        if (!password.Any(char.IsDigit))
            Console.WriteLine("- Include at least one number");

        if (!password.Any(char.IsUpper))
            Console.WriteLine("- Include at least one uppercase letter");

        if (!password.Any(char.IsLower))
            Console.WriteLine("- Include at least one lowercase letter");

        if (!password.Any(ch => "!@#$%^&*()_-+=<>?".Contains(ch)))
            Console.WriteLine("- Add special symbols like !@#$%^&*");

        Console.WriteLine();

    }

}
