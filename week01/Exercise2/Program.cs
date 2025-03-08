using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string percentageInput = Console.ReadLine();

        int percentage = int.Parse(percentageInput);
        string letter;

        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int remainder = percentage % 10;
        string sign;

        if (remainder >= 7 && letter != "A" && letter != "F")
        {
            sign = "+";
        }
        else if (remainder < 3 && letter != "F")
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        Console.WriteLine($"Your grade is: {letter}{sign}.");

        if (percentage >= 70)
        {
            Console.WriteLine("You passed! Congratulations!");
        }
        else
        {
            Console.WriteLine("Sorry, you didn't passed. Do your best next time! I know you can do it!");
        }
    }
}
