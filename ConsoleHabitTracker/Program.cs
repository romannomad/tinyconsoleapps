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

    }

}