using System;
using System.IO;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "";
        _description = "";
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Actiivity.\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long, in seconds, would you like for your session? ");

        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);

        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        string spinner = "|/-\\";
        int i = 0;
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("\b \b");
            Console.Write(spinner.Substring(i, 1));
            Thread.Sleep(200);

            i++;
            i %= spinner.Length;
        }

        Console.Write("\b \n");
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write("\b \b");
            Console.Write(i);
            Thread.Sleep(1000);
        }

        Console.Write("\b \n");
    }

    public void RecordActivity()
    {
        Console.Write("Do you want to record your activity? (y/n) ");

        string record = Console.ReadLine();

        if (record == "y")
        {
            Console.Write("Recording activity... ");
            ShowSpinner(5);

            string fileName = $"{_name.ToLower()}_activity.txt";

            using (StreamWriter writer = new(fileName, true))
            {
                writer.WriteLine($"{DateTime.Now} - {_name} Activity - {_duration} seconds.");
            }

            Console.WriteLine("Activity recorded successfully!");
            ShowSpinner(3);
        }
    }

    public void ViewRecordedActivity(string type)
    {
        List<string> types = ["breathing", "reflecting", "listing"];

        if (types.IndexOf(type) >= 0)
        {
            string fileName = $"{type}_activity.txt";

            if (File.Exists(fileName))
            {
                using (StreamReader reader = new(fileName))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine($"No record for {type} activity.");
            }
        }

        Console.Write("\nPress any key to continue...");
        Console.ReadLine();
    }
}
