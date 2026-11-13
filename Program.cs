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
        Console.WriteLine();
        Console.WriteLine("Choose a Monster to Inspect");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine();
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
        try
        {


            Console.Clear();


            Console.WriteLine("His stats are: ");
            Console.WriteLine();

            string[] monsterStats = File.ReadAllLines(filePath);

            string name = "";
            int age = 0;
            int health = 0;
            int strength = 0;
            int dexterity = 0;
            int intelligence = 0;
            int wisdom = 0;

            foreach (string line in monsterStats)
            {
                if (line.Contains("="))
                {
                    string[] monsterText = line.Split('=');

                    string desc = monsterText[0].Trim();
                    string value = monsterText[1].Trim();

                    switch (desc)
                    {
                        case "name":
                            name = value;
                            break;
                        case "age":
                            age = int.Parse(value);
                            break;
                        case "health":
                            health = int.Parse(value);
                            break;
                        case "strength":
                            strength = int.Parse(value);
                            break;
                        case "dexterity":
                            dexterity = int.Parse(value);
                            break;
                        case "intelligence":
                            intelligence = int.Parse(value);
                            break;
                        case "wisdom":
                            wisdom = int.Parse(value);
                            break;

                    }

                }


            }

            if (name == "" || age == 0 || health == 0 ||
                strength == 0 || dexterity == 0 ||
                intelligence == 0 || wisdom == 0)
            {
                throw new FormatException();
            }

            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Strength: " + strength);
            Console.WriteLine("Dexterity: " + dexterity);
            Console.WriteLine("Intelligence: " + intelligence);
            Console.WriteLine("Wisdom: " + wisdom);

            int powerLevel = health / 2 + strength * 2 + dexterity + intelligence + wisdom / 2;

            Console.SetCursorPosition(0, 12);
            Console.WriteLine("PowerLevel: " + powerLevel);


            string rarity = "";

            if (powerLevel > 5000)
                rarity = "immortal";
            else if (powerLevel > 2500)
                rarity = "godly";
            else if (powerLevel > 1000)
                rarity = "mythical";
            else if (powerLevel > 500)
                rarity = "legendary";
            else if (powerLevel > 250)
                rarity = "epic";
            else if (powerLevel > 100)
                rarity = "rare";
            else if (powerLevel < 100)
                rarity = "common";


            Console.SetCursorPosition(0, 13);
            Console.WriteLine("Rarity: " + rarity);


            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Exit[1]");

            ConsoleKeyInfo Input = Console.ReadKey();

            if (Input.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Main();
            }
            else
            {
                Console.WriteLine("Invalid Input");
                Console.ReadKey();
                Console.Clear();
                Main();
            }
        }
        catch (Exception error)
        {
            Console.Clear();

            Console.WriteLine(error.Message);
            Console.WriteLine("Please choose another file.");
            Console.ReadKey();
            
            Main();
        }
    }
        

}
    





