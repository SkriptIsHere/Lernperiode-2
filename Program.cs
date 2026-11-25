using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Linq;
class Monster_Inspector
{

    static string name = "";
    static int age = 0;
    static int health = 0;
    static int strength = 0;
    static int dexterity = 0;
    static int intelligence = 0;
    static int wisdom = 0;


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
        Console.WriteLine("Press 3 to choose Create Monster");
        Console.WriteLine("Press Space to import your own Monster");
        Console.WriteLine("Press L to view your creations");

        Console.ResetColor();

        ConsoleKeyInfo Input = Console.ReadKey();

        if (Input.Key == ConsoleKey.D1)
        {
            LoadMonster("..\\..\\..\\Creeper-Stats.txt");
        }
        else if (Input.Key == ConsoleKey.D2)
        {
            LoadMonster("..\\..\\..\\Bobby-Stats.txt");
        }
        else if (Input.Key == ConsoleKey.D3)
        {
            CreateMonster();
        }
        else if (Input.Key == ConsoleKey.L)
        {
            MonsterList();
        }
        else if (Input.Key == ConsoleKey.Spacebar)
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

    static void CreateMonster()
    {
        Console.Clear();
        Console.WriteLine("---Create your Monster---");
        Console.WriteLine("");

        name = ReadString("Name: ");
        age = ReadInt("Age: ");
        health = ReadInt("Health: ");
        strength = ReadInt("Strength: ");
        dexterity = ReadInt("Dexterity: ");
        intelligence = ReadInt("Intelligence: ");
        wisdom = ReadInt("Wisdom: ");

        Console.WriteLine("");
        Console.WriteLine("-Preview-");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Strength: {strength}");
        Console.WriteLine($"Dexterity: {dexterity}");
        Console.WriteLine($"Intelligence: {intelligence}");
        Console.WriteLine($"Wisdom: {wisdom}");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Saved in Libary");
        Console.ResetColor();


        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Save Monster";
            saveFileDialog.FileName = name + "-Stats.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] lines =
                    {
                    "name=" + name,
                    "age=" + age,
                    "health=" + health,
                    "strength=" + strength,
                    "dexterity=" + dexterity,
                    "intelligence=" + intelligence,
                    "wisdom=" + wisdom
                    };

                try
                {
                    File.WriteAllLines(saveFileDialog.FileName, lines);
                    AddToMonsterList(saveFileDialog.FileName);
                }
                catch (Exception ex) { }
                


            }

        }
        Console.ReadKey();
        Console.Clear();
        Main();
        return;



    }
    static string monsterListPath = "..\\..\\..\\MonsterList.txt";

    static void AddToMonsterList(string filePath)
    {

            if (!File.Exists(monsterListPath))
                File.Create(monsterListPath).Close();

            string[] existing = File.ReadAllLines(monsterListPath);

            if (!existing.Contains(filePath))
            {
                File.AppendAllText(monsterListPath, filePath + Environment.NewLine);
            }
        

    }

    static void MonsterList()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("--- My Monsters ---");
        Console.ResetColor();
        Console.WriteLine();

        string[] paths = GetMonsterList();

        if (paths.Length == 0)
        {
            Console.WriteLine("(no monsters created yet)");
            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Console.Clear();
            Main();
            return;
        }

       
        for (int i = 0; i < paths.Length; i++)
        {
            
            Console.WriteLine("[" + (i + 1) + "] " + Path.GetFileName(paths[i]));
        }

        Console.WriteLine();
        Console.WriteLine("Enter number to inspect (0 = back): ");

        string input = Console.ReadLine();
        int choice;
        if (!int.TryParse(input, out choice))
        {
            Console.Clear();
            Main();
            return;
        }

        if (choice == 0)
        {
            Console.Clear();
            Main();
            return;
        }

        if (choice >= 1 && choice <= paths.Length)
        {
            
            string selectedPath = paths[choice - 1];
            LoadMonster(selectedPath);

            Console.Clear();
            Console.WriteLine("His stats are: ");
            Console.WriteLine();
            

            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Invalid number.");
            Console.ReadKey();
        }

        Console.Clear();
        Main();

    }

    static string[] GetMonsterList()
    {
        if (!File.Exists(monsterListPath))
            return new string[0];

        string[] paths = File.ReadAllLines(monsterListPath);

        string[] existingPaths = paths
            .Where(path => File.Exists(path))
            .ToArray();

        File.WriteAllLines(monsterListPath, existingPaths);

        return existingPaths;
    }

    static void LoadMonster(string filePath)
    {
        try
        {


            Console.Clear();


            Console.WriteLine("His stats are: ");
            Console.WriteLine();

            string[] monsterStats = File.ReadAllLines(filePath);



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

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, 12);
            Console.WriteLine("PowerLevel: " + powerLevel);



            string rarity = "";

            if (powerLevel > 5000)
        
                rarity = "immortal (Highest rarity)";
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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, 13);
            Console.WriteLine("Rarity: " + rarity);
            Console.ResetColor();


            string type = "";

            if (strength > 500)
                type = "Berserk";
            else if (health > 500)
                type = "Tank";
            else if (intelligence > 500)
                type = "Mage";
            else if (dexterity > 500)
                type = "Assasin";
            else if (wisdom > 500)
                type = "Sage";
            else
                type = "Normal";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0, 14);
            Console.WriteLine("Type: " + type);
            Console.ResetColor();






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

    static string ReadString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            return input.Trim();

        }
    }

    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int value) && value > 0)
            return value;



        }
    }
}









