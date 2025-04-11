using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        // Nothing to do here
    }

    public override void RecordEvent()
    {
        // Nothing to do here
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"{GetType().Name}:{_shortName}|{_description}|{_points}";
    }
}
