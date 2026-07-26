using System.Text.Json;

class Habit
{
    public string Name { get; set; }
    public int CountThisWeek { get; set; }

}

class Program
{
    static string filePath = "habits.json";
    static List<Habit> habits = new();

    static void Main()
    {
        Load();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== Habit Tracker ===");
            Console.ResetColor();

            Console.WriteLine("1. Add Habit");
            Console.WriteLine("2. Mark habit as done today");
            Console.WriteLine("3. Show weekly stats");
            Console.WriteLine("4. Reset weekly stats");
            Console.WriteLine("5. Exit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddHabit();
                    break;
                case "2":
                    MarkDone();
                    break;
                case "3":
                    ShowStats();
                    break;
                case "4":
                    ResetStats();
                    break;
                case "5":
                    Save();
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

    static void AddHabit()
    {
        Console.Write("Habit name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty.");
            return;
        }

        habits.Add(new Habit { Name = name, CountThisWeek = 0 });
        Save();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Habit added!");
        Console.ResetColor();
    }

    static void MarkDone()
    {
        if (habits.Count == 0)
        {
            Console.WriteLine("No habits yet");
            return;
        }

        Console.WriteLine("Select a habit: ");
        for (int i = 0; i < habits.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {habits[i].Name}");
        }

        Console.Write("Choose: ");
        if (int.TryParse(Console.ReadLine(), out int index)
        && index >= 1 && index <= habits.Count)
        {

        }


    }

}