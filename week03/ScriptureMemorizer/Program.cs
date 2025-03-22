// Exceeding requirements. Added a feature to ask the user for input on the number of random words to hide.
// The program hides the number of random words specified by the user and displays the text with the hidden words.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of random words to hide: ");

        int numberToHide = int.Parse(Console.ReadLine());
        string text = "Angels speak by the power of the Holy Ghost; wherefore, they speak the words of Christ. Wherefore, I said unto you, feast upon the words of Christ; for behold, the words of Christ will tell you all things what ye should do.";

        Reference reference = new Reference("2 Nephi", 32, 3);
        Scripture scripture = new Scripture(reference, text);

        DisplayScripture(scripture);

        while (!scripture.IsCompletelyHidden() && Console.ReadLine() != "quit")
        {
            scripture.HideRandomWords(numberToHide);
            DisplayScripture(scripture);
        }
    }

    private static void DisplayScripture(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        Console.WriteLine("Press enter to continue or type 'quit' to finish:");
    }
}
