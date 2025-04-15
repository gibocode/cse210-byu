using System;

public abstract class Activity
{
    private string _date;
    protected double _length;

    public Activity(double length)
    {
        _date = DateTime.Now.ToString("dd MMM yyyy");
        _length = length;
    }

    protected abstract double GetDistance();
    protected abstract double GetSpeed();
    protected abstract double GetPace();

    public string GetSummary()
    {
        string type = GetType().Name.Replace("Activity", "");

        return $"{_date} {type} ({_length} min): Distance {GetDistance():0.##} km, Speed {GetSpeed():0.##} kph, Pace {GetPace():0.##} min per km";
    }
}
