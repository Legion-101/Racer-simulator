static class TransportFunction
{
    public static double Func1(int _time)
    {
        return 5.92 + _time;
    }

    public static double Func2(int _time)
    {
        return 2.42 * _time;
    }

    public static double Func3(int _time)
    {
        return Math.Pow(_time, 0.66);
    }

    public static double Func4(int _time)
    {
        return 6 * (Math.Abs(Math.Cos(_time)) + 1.145);
    }

    public static double Func5(int _dist)
    {
        return (Math.Abs(Math.Cos(_dist)) + 0.2) * Math.Pow(_dist, 1.153);
    }

    public static double Func6(int _dist)
    {
        return (Math.Abs(Math.Sin(_dist)) + 1.123) * (Math.Abs(Math.Tan(_dist)) + 1.14);
    }

    public static double Func7(int _dist)
    {
        return (12 * Math.Abs(Math.Sin(_dist)) + 31) / 1.621;
    }

    public static double Func8(int _dist)
    {
        return Math.Pow(_dist, 1.125) * Math.Abs(Math.Sin(_dist)) + 0.1;
    }
}