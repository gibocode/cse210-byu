using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new RunningActivity(30, 4.8));
        activities.Add(new CyclingActivity(30, 5.6));
        activities.Add(new SwimmingActivity(30, 20));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
