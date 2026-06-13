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
            Console.WriteLine("1. Add Note");
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



        }
    }
}