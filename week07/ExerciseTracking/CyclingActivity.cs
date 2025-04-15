using System;

public class CyclingActivity : Activity
{
    private double _speed;

    public CyclingActivity(double length, double speed) : base(length)
    {
        _speed = speed;
    }

    protected override double GetDistance()
    {
        return _speed * _length / 60;
    }

    protected override double GetSpeed()
    {
        return _speed;
    }

    protected override double GetPace()
    {
        return _length / GetDistance();
    }
}
