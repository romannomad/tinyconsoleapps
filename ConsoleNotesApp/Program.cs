using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static string notesFilePath = "notes.txt";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Add Note");//     
            Console.WriteLine("2. View Notes");
            Console.WriteLine("3. Delete all notes");
            Console.WriteLine("4. Exit");
            Console.Write("Choose: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNote();
                    break;

                case "2":
                    ListNotes();
                    break;

                case "3":
                    DeleteNotes();
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AddNote()
    {
        Console.Write("Enter your note: ");
        var note = Console.ReadLine();
        File.AppendAllText(notesFilePath, note + Environment.NewLine);
        Console.WriteLine("Saved.");
    }

    static void ListNotes()
    {
        if (File.Exists(notesFilePath))
        {
            Console.WriteLine("No notes yet");
            return;
        }

        var notes = File.ReadAllLines(notesFilePath);
        if (notes.Length == 0)
        {
            Console.WriteLine("No notes yet");
            return;
        }

        Console.WriteLine("Notes: ");
        foreach (var n in notes)
            Console.WriteLine("-" + n);
    }

    static void DeleteNotes()
    {
        if (File.Exists(notesFilePath))
        {
            File.Delete(notesFilePath);
        }
        Console.WriteLine("All notes deleted");
    }
}