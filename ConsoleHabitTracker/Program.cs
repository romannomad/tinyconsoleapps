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


            }
        }

    }

}