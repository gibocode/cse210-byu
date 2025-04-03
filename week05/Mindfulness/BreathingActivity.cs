using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreath in... ");
            ShowCountDown(5);

            Console.Write("Now breath out... ");
            ShowCountDown(5);
        }

        DisplayEndingMessage();
        RecordActivity();
    }
}
