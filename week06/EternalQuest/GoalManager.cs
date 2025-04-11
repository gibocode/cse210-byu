using System;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager()
    {
        _score = 0;
    }

    public void Start()
    {
        int choice = 0;

        while (choice != 7)
        {
            DisplayPlayerInfo();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Remove Goal");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                CreateGoal();
            }
            else if (choice == 2)
            {
                ListGoalDetails();
            }
            else if (choice == 3)
            {
                SaveGoals();
            }
            else if (choice == 4)
            {
                LoadGoals();
            }
            else if (choice == 5)
            {
                RecordEvent();
            }
            else if (choice == 6)
            {
                RemoveGoal();
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    private void ListGoalNames(bool includeComplete = false)
    {
        Console.WriteLine("The goals are:");
        int goalCount = 1;

        foreach (Goal goal in _goals)
        {
            if (includeComplete || !goal.IsComplete())
            {
                Console.WriteLine($"{goalCount}. {goal.GetName()}");
                goalCount++;
            }
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        int goalCount = 1;

        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{goalCount}. {goal.GetDetailsString()}");
            goalCount++;
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The type of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;

        if (choice == 1)
        {
            goal = new SimpleGoal(name, description, points);
        }
        else if (choice == 2)
        {
            goal = new EternalGoal(name, description, points);
        }
        else if (choice == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            goal = new ChecklistGoal(name, description, points, target, bonus);
        }

        if (goal != null)
        {
            _goals.Add(goal);
            Console.WriteLine("Goal created successfully.");
        }
    }

    private void RecordEvent()
    {
        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());
        int goalCount = 1;

        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete())
            {
                continue;
            }

            if (goalCount == choice)
            {
                goal.RecordEvent();
                _score += goal.GetPoints();
                Console.WriteLine($"Congratulations! You have earned {goal.GetPoints()} points!");
                break;
            }

            goalCount++;
        }

        Console.WriteLine($"You have now {_score} points.");
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                writer.Write($"{goal.GetStringRepresentation()}\n");
            }
        }
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line = reader.ReadLine();
            _score = int.Parse(line);

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                string type = parts[0].Split(':')[0];
                string name = parts[0].Split(':')[1];
                string description = parts[1];
                int points = int.Parse(parts[2]);

                if (type == "SimpleGoal")
                {
                    SimpleGoal goal = new SimpleGoal(name, description, points);
                    bool isComplete = bool.Parse(parts[3]);
                    if (isComplete)
                    {
                        goal.RecordEvent();
                    }
                    _goals.Add(goal);
                }
                else if (type == "EternalGoal")
                {
                    EternalGoal goal = new EternalGoal(name, description, points);
                    _goals.Add(goal);
                }
                else if (type == "ChecklistGoal")
                {
                    int bonus = int.Parse(parts[3]);
                    int target = int.Parse(parts[4]);
                    ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
                    int amountCompleted = int.Parse(parts[5]);
                    for (int i = 0; i < amountCompleted; i++)
                    {
                        goal.RecordEvent();
                    }
                    _goals.Add(goal);
                }
            }
        }
    }

    private void RemoveGoal()
    {
        ListGoalNames(true);

        Console.Write("Which goal would you like to remove? ");
        int choice = int.Parse(Console.ReadLine());
        int goalCount = 1;

        foreach (Goal goal in _goals)
        {
            if (goalCount == choice)
            {
                _goals.Remove(goal);
                Console.WriteLine("Goal removed successfully.");
                break;
            }

            goalCount++;
        }
    }
}
