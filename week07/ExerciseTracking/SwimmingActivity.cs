using System;

public class SwimmingActivity : Activity
{
    private int _laps;

    public SwimmingActivity(double length, int laps) : base(length)
    {
        _laps = laps;
    }

    protected override double GetDistance()
    {
        return _laps * 50.0 / 1000;
    }

    protected override double GetSpeed()
    {
        return GetDistance() / _length * 60;
    }

    protected override double GetPace()
    {
        return _length / GetDistance();
    }
}
