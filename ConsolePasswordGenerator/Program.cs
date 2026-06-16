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


    }
}
