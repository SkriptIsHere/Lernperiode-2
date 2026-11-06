using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
class Monster_Inspector
{
    [STAThread]

    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Welcome to Monster-Inspector");
        Console.ResetColor();
        Console.WriteLine("Choose a Monster to Inspect");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Press 1 to choose Creeper");
        Console.WriteLine("Press 2 to choose Bobby");
        Console.WriteLine("Press Space to import your own Monster");
        Console.ResetColor();

        ConsoleKeyInfo Input = Console.ReadKey();

        if (Input.Key == ConsoleKey.D1)
        {
            LoadMonster("..\\..\\..\\Creeper-Stats.txt");
        }
        else if(Input.Key == ConsoleKey.D2)
        {
            LoadMonster("..\\..\\..\\Bobby-Stats.txt");
        }
        else if(Input.Key == ConsoleKey.Spacebar)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    LoadMonster(selectedFilePath);
                }
            }

        }
            Console.ReadKey();
    }

    static void LoadMonster(string filePath)
    {
        Console.Clear();
        

        Console.WriteLine("His stats are: ");
        Console.WriteLine();

        string[] monsterStats = File.ReadAllLines(filePath);

        string name = "";
        int age = 0;
        int health = 0;
        int attackpower = 0;

        foreach (string line in monsterStats)
        {
            if (line.Contains("="))
            {
                string[] creeperText = line.Split('=');

                string desc = creeperText[0];
                string value = creeperText[1];

                if (desc == "name")
                {
                    name = value;

                }
                else if (desc == "age")
                {
                    age = int.Parse(value);
                }
                else if (desc == "health")
                {

                    health = int.Parse(value);
                }
                else if (desc == "attackpower")
                {
                    attackpower = int.Parse(value);
                }

            }



        }

        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age: " + age);
        Console.WriteLine("Health: " + health);
        Console.WriteLine("Attackpower: " + attackpower);



    }
}




