using System;
using System.IO;
class Monster_Inspector
{
    static void Main()
    {
        Console.WriteLine("Welcome to Monster-Inspector");
        Console.WriteLine("Choose a Monster to Inspect");
        Console.WriteLine("Press 1 to choose Creeper");

        ConsoleKeyInfo Input = Console.ReadKey();

        if (Input.Key == ConsoleKey.D1)
        {
            Creeper();

        }
        Console.ReadKey();
    }

    static void Creeper()
    {
        Console.Clear();
        Console.WriteLine("This is: ");

        Console.WriteLine("His stats are: ");
        CreeperStats();

    }

    public static void CreeperStats()
    {
        string CreeperStats = File.ReadAllText("..\\..\\..\\Creeper-Stats.txt");

        Console.WriteLine(CreeperStats);
    }
}



