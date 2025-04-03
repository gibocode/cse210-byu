using System;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = [];

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        _prompts = [
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        ];
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();

        Console.WriteLine("List as many responses you can do to the following prompt:");
        Console.WriteLine($" --- {prompt} ---");
        Console.Write("You may begin in:  ");

        ShowCountDown(5);

        List<string> list = GetListFromUser();

        _count = list.Count;

        Console.WriteLine($"You listed {_count} items!\n");

        DisplayEndingMessage();
        RecordActivity();
    }

    private string GetRandomPrompt()
    {
        Random random = new();
        return _prompts[random.Next(1, _prompts.Count)];
    }

    private List<string> GetListFromUser()
    {
        List<string> list = [];
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            list.Add(Console.ReadLine());
        }

        return list;
    }
}
