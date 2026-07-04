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
        string choice = Console.ReadLine() ?? "2";

        string algorithm = choice switch
        {
            "1" => "MD5",
            "2" => "SHA256",
            "3" => "SHA512",
            _ => "SHA256"
        };

        string hash = ComputeHash(input, algorithm);

        Console.WriteLine($"\nAlgorithm: {algorithm}");
        Console.WriteLine($"Input   : {input}");
        Console.WriteLine($"Hash    : {hash}");
    }

    static string ComputeHash(string input, string algorithmName)
    {
        using HashAlgorithm algorithm = algorithmName switch
        {

        }
    }
}
