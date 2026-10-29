using System;
using System.Reflection.Metadata;
using System.IO;

class ServerManager
{
    static bool onlineStatus = false;


    static void Main()
    {
        
        bool weiter = true;

        while (weiter == true)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("---------------");
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("SERVER MANAGER");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("---------------");

            Console.ResetColor();

            Console.SetCursorPosition(0, 4);
            Console.WriteLine("[1] Server starten");
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("[2] Server beenden");
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("[3] Serverstatus anzeigen");
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("[4] Program beenden");

            ConsoleKeyInfo eingabe = Console.ReadKey();

            if (eingabe.Key == ConsoleKey.D1)
            {
                ServerStarten();

            }

            if (eingabe.Key == ConsoleKey.D2)
            {
                ServerBeenden();

            }

            if (eingabe.Key == ConsoleKey.D3)
            {
                Console.Clear();
                
                PresetFile();
                weiter = false;

            }

            if (eingabe.Key == ConsoleKey.D4)
            {
                weiter = false;

            }
        }

    }

    static void Text(string text)
    {

        foreach (char buchstabe in text)
        {
            Console.Write(buchstabe);
            Thread.Sleep(100);
        }

    }

    static void ServerStarten()
    {
        if (onlineStatus == false)
        {
            Console.Clear();

            Text("Server wird gestartet...");
            onlineStatus = true;
        }
        else
        {
            Console.Clear();

            Text("Server ist bereits Online");
        }

        Console.ReadKey();
    }

    static void ServerBeenden()
    {
        if (onlineStatus == true)
        {
            Console.Clear();

            Text("Server wird beendet...");
            onlineStatus = false;

        }
        else
        {
            Console.Clear();

            Text("Server ist bereits Offline");
        }
        Console.ReadKey();


    }

    static void ServerStatus()
    {
        Console.Clear();

        if (onlineStatus == true)
        {

            Console.WriteLine("Server ist Online");
        }
        else
        {
            Console.WriteLine("Server ist Offline");
        }

        Console.ReadKey();
    }

    static void PresetFile()
    { 

     
     string[] zeilen = File.ReadAllLines("..\\..\\..\\ServerInfo.txt");

     string spielerText = zeilen[0].Split('=')[1];

        
     int spielerCount = Convert.ToInt32(spielerText);

     Console.SetCursorPosition(0, 1);
     Console.WriteLine("Player Count: ");
     Console.Write(spielerCount);

        string serverLoadText = zeilen[2].Split('=')[1];


        int systemOverload = Convert.ToInt32(serverLoadText);

        Console.SetCursorPosition(0, 3);
        Console.WriteLine("SystemOverload: ");
        Console.Write(systemOverload);

    }


}

