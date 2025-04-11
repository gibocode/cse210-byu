// Exceeding Requirements - Added feature to remove and not display completed goals when recording an event. Only unfinished goals can be updated.
// Added feature to remove specific goals from the list.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        goalManager.Start();
    }
}
