using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("===Hash Generator===");

        Console.WriteLine("Enter text to hash: ");
        string input = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Choose algorithm:");
        Console.WriteLine("1) MD5");
        Console.WriteLine("2) SHA256");
        Console.WriteLine("3) SHA512");
        Console.WriteLine("Your choice (1-3): ");



    }
}
