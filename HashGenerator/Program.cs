using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("===Hash Generator===");// Display the title of the program to the user

        Console.WriteLine("Enter text to hash: ");// Prompt the user to enter the text to hash
        string input = Console.ReadLine() ?? string.Empty;// Read the user input and default to an empty string if no input is provided

        Console.WriteLine("Choose algorithm:"); // Prompt the user to select a hashing algorithm
        Console.WriteLine("1) MD5");// Display the option for MD5 hashing algorithm
        Console.WriteLine("2) SHA256");// Display the option for SHA256 hashing algorithm
        Console.WriteLine("3) SHA512");// Display the option for SHA512 hashing algorithm
        Console.WriteLine("Your choice (1-3): "); // Prompt the user to select a hashing algorithm
        string choice = Console.ReadLine() ?? "2"; // Default to SHA256 if no choice is made

        string algorithm = choice switch // Select the hashing algorithm based on user input
        {
            "1" => "MD5", // Use MD5 if the user selects option 1
            "2" => "SHA256", // Use SHA256 if the user selects option 2
            "3" => "SHA512", // Use SHA512 if the user selects option 3
            _ => "SHA256"
        };

        string hash = ComputeHash(input, algorithm);// Compute the hash of the input string using the selected algorithm

        Console.WriteLine($"\nAlgorithm: {algorithm}");// Display the selected algorithm to the user
        Console.WriteLine($"Input   : {input}"); // Display the original input to the user
        Console.WriteLine($"Hash    : {hash}");// Display the computed hash to the user
    }

    static string ComputeHash(string input, string algorithmName) // Method to compute the hash of the input string using the specified algorithm
    {
        using HashAlgorithm algorithm = algorithmName switch
        {
            "MD5" => MD5.Create(), // Create an instance of the MD5 hash algorithm
            "SHA256" => SHA256.Create(), // Create an instance of the SHA256 hash algorithm
            "SHA512" => SHA512.Create(), // Create an instance of the SHA512 hash algorithm
            _ => SHA256.Create() // Default to SHA256 if an unknown algorithm is specified

        };

        byte[] bytes = Encoding.UTF8.GetBytes(input); // Convert the input string to a byte array using UTF-8 encoding
        byte[] hashBytes = algorithm.ComputeHash(bytes);// Compute the hash of the byte array using the selected hash algorithm

        StringBuilder sb = new(); // Create a StringBuilder to build the hash string representation
        foreach (byte b in hashBytes) // Iterate through each byte in the hash byte array
        {
            sb.Append(b.ToString("x2"));// Convert each byte to a hexadecimal string and append it to the StringBuilder
        }

        return sb.ToString();// Return the final hash string representation
    }

    static string ComputeFileHash(string filePath, string algorithmName)
    {
        using HashAlgorithm algorithm = algorithmName switch
        {
            "MD%" => MD5.Create(),
            "SHA256" => SHA256.Create(),
            "SHA512" => SHA512.Create(),
            _ => SHA256.Create()
        };

        using FileStream stream = File.OpenRead(filePath);
        byte[] hashBytes = algorithm.ComputeHash(stream);

        StringBuilder sb = new();
        foreach (byte b in hashBytes)
        {
            sb.Append(b.ToString("x2"));
        }

        return sb.ToString();

    }
}
