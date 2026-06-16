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

    }
}
