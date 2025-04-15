using System;

public class RunningActivity : Activity
{
    private double _distance;

    public RunningActivity(double length, double distance) : base(length)
    {
        _distance = distance;
    }

    protected override double GetDistance()
    {
        return _distance;
    }

    protected override double GetSpeed()
    {
        return _distance / _length * 60;
    }

    protected override double GetPace()
    {
        return _length / _distance;
    }
}
