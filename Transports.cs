internal class Transport
{
    internal string name { get; set; }
    internal int speed { get; set; }

    internal Transport(string _name, int _speed)
    {
        name = _name;
        speed = _speed;
    }
}

internal class GroundTransport : Transport
{
    internal int timeBeforePause { get; set; } 

    internal Func<int, double> funcDurationOfPause { get; set; }

    internal GroundTransport(string _name, int _speed, int _timeBeforeRest, Func<int, double> _func)
    : base(_name, _speed)
    {
        timeBeforePause = _timeBeforeRest;
        funcDurationOfPause = _func;
    }
    internal double durationOfRest(int _stopNumber)
    {
        return funcDurationOfPause(_stopNumber);
    }
}

class AirTransport : Transport
{
    internal Func<int, double> funcAccelerationFactor { get; set; }
    internal AirTransport(string _name, int _speed, Func<int, double> _func)
    : base(_name, _speed)
    {
        funcAccelerationFactor = _func;
    }

    internal double accelerationFactor(int _distance)
    {
        return funcAccelerationFactor(_distance);
    }
}