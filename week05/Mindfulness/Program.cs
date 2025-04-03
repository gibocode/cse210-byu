// Exceeding Requirements - Added a feature to RECORD and VIEW activities
// There's a 4th menu option to view your recorded activities and there's an option too to record your activity after every session.

using System;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 5)
        {
            Console.Clear();
            Console.WriteLine("Menu Options.");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View recorded activity");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                BreathingActivity breathingActivity = new();
                breathingActivity.Run();
            }
            else if (choice == 2)
            {
                ReflectingActivity reflectingActivity = new();
                reflectingActivity.Run();
            }
            else if (choice == 3)
            {
                ListingActivity listingActivity = new();
                listingActivity.Run();
            }
            else if (choice == 4)
            {
                DisplaySelection();
            }
        }
    }

    static void DisplaySelection()
    {
        int choice = 0;

        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Select an activity to view:");
            Console.WriteLine("  1. Breathing");
            Console.WriteLine("  2. Reflecting");
            Console.WriteLine("  3. Listing");
            Console.WriteLine("  4. Cancel");
            Console.Write("Enter number of choice: ");

            choice = int.Parse(Console.ReadLine());

            if (choice > 0 && choice < 4)
            {
                List<string> types = ["breathing", "reflecting", "listing"];
                Activity activity = new();

                activity.ViewRecordedActivity(types[choice - 1]);
                break;
            }
        }
    }
}
