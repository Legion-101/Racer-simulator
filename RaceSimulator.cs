internal class ResultRace
{
    internal string name { get; set; }
    internal double time { get; set; }
    internal int countRest { get; set; }

    internal ResultRace(string _name, double _time, int _countRest)
    {
        name = _name;
        time = _time;
        countRest = _countRest;
    }

    internal ResultRace(string _name, double _time)
    {
        name = _name;
        time = _time;
    }
}

class RaceSimulator
{
    private int distance;
    private List<Transport> transports;

    internal RaceSimulator(int _distance, List<Transport> _transports)
    {
        distance = _distance;
        transports = _transports;
    }

    internal List<ResultRace> Start()
    {
        List<ResultRace> result = new List<ResultRace>();
        transports.ForEach((Transport) =>
        {
            int dist = distance;

            if (Transport is GroundTransport)
            {
                GroundTransport groundTransport = (GroundTransport) Transport;
                int restNumber = 0;
                double time = 0;

                while (dist > 0)
                {
                    int distanceBeforePause = groundTransport.timeBeforePause * groundTransport.speed;

                    if (distanceBeforePause >= dist)
                    {
                        time = time + dist / groundTransport.speed;

                    }
                    else
                    {
                        time = time + distanceBeforePause / groundTransport.speed;
                        restNumber++;
                        time = groundTransport.durationOfRest(restNumber);
                    }

                    dist = dist - distanceBeforePause;
                }
                result.Add(new ResultRace(groundTransport.name, Math.Round(time, 2), restNumber));
            }
            else if (Transport is AirTransport)
            {
                AirTransport airTransport = (AirTransport) Transport;
                double time = 0;

                for (int i = 1; i < distance; i++)
                {
                    double accelerationFactor = airTransport.accelerationFactor(i);
                    time = time + (1 / (airTransport.speed * accelerationFactor));
                }
                result.Add(new ResultRace(airTransport.name, Math.Round(time, 2)));
            }
        });

        return result;
    }
}