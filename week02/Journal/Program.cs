// Exceeding Requirements. Added an option to SEARCH an entries through a keyword.
// The program will only display the entries that was filtered by the keyword.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");

        Journal journal = new Journal();
        int choice;

        do
        {
            Console.WriteLine("Please select one of the following choices");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Search");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Entry entry = new Entry();
                PromptGenerator promptGenerator = new PromptGenerator();

                string randomPrompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine(randomPrompt);
                Console.Write("> ");

                entry._promptText = randomPrompt;
                entry._entryText = Console.ReadLine();

                journal.AddEntry(entry);
            }
            else if (choice == 2)
            {
                journal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.WriteLine("What is the filename? ");
                string file = Console.ReadLine();

                journal.LoadFromFile(file);
            }
            else if (choice == 4)
            {
                Console.WriteLine("What is the filename? ");
                string file = Console.ReadLine();

                journal.SaveToFile(file);
            }
            // Search entries. This is the added feature as part of exceeding requirements
            else if (choice == 5)
            {
                Console.WriteLine("Enter a keyword to search: ");
                string keyword = Console.ReadLine();

                journal.SearchEntries(keyword);
            }

        } while (choice != 6);
    }
}
