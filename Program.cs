internal class Program
{
    internal static int[] GetGroundTransports()
    {
        bool isReadyForContinue = true;
        int[] validValues = { 1, 2, 3, 4 };

        Console.WriteLine(  "  1 - Сапоги-скороходы\n" +
                            "  2 - Карета-тыква\n" +
                            "  3 - Избушка на курьих ножках\n" +
                            "  4 - Кентавр\n"
            );

        int[] results = Array.Empty<int>();

        while (isReadyForContinue)
        {
            List<int> notValid = new List<int>();

            results = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (int result in results)
            {
                if (!validValues.Contains(result))
                {
                    notValid.Add(result);
                }
            }

            if (notValid.Count == 0)
            {
                isReadyForContinue = false;
            }
            else
            {
                Console.WriteLine("Введенные значения не входят в допустимый диапазон(" + string.Join(", ", notValid) + "). Введите заново:");
            }
        }

        return results;
    }

    internal static int[] GetAirTransports()
    {
        bool isRead = true;
        int[] validValues = { 5, 6, 7, 8 };

        Console.WriteLine(  "  5 - Ступа Бабы Яги\n" +
                            "  6 - Метла\n" +
                            "  7 - Ковер-самолет\n" +
                            "  8 - Летучий корабль\n"
            );

        int[] results = Array.Empty<int>();

        while (isRead)
        {
            List<int> notValid = new List<int>();

            results = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (int result in results)
            {
                if (!validValues.Contains(result))
                {
                    notValid.Add(result);
                }
            }

            if (notValid.Count == 0)
            {
                isRead = false;
            }
            else
            {
                Console.WriteLine($"Введенные значения не входят в допустимый диапазон({ string.Join(", ", notValid)}). Введите заново:");
            }
        }

        return results;
    }

    static int[] GetTransports()
    {
        bool isRead = true;
        int[] validValues = { 1, 2, 3, 4, 5, 6, 7, 8 };
        Console.WriteLine(  "  1 - Сапоги-скороходы\n" +
                            "  2 - Карета-тыква\n" +
                            "  3 - Избушка на курьих ножках\n" +
                            "  4 - Кентавр\n" +
                            "  5 - Ступа Бабы Яги\n" +
                            "  6 - Метла\n" +
                            "  7 - Ковер-самолет\n" +
                            "  8 - Летучий корабль\n"
            );

        int[] results = { };

        while (isRead)
        {
            List<int> notValid = new List<int>();
            results = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (int result in results)
            {
                if (!validValues.Contains(result))
                {
                    notValid.Add(result);
                }
            }

            if (notValid.Count == 0)
            {
                isRead = false;
            }
            else
            {
                Console.WriteLine(
                    $"Введенные значения не входят в допустимый диапазон({string.Join(", ", notValid)}). Введите заново:"
                );
            }
        }

        return results;
    }

    static Transport CreateTransport(int idTr)
    {
        switch (idTr)
        {
            case 1: return new GroundTransport("Сапоги-скороходы", 25, 3, TransportFunction.Func1);
            case 2: return new GroundTransport("Карета-тыква", 20, 5, TransportFunction.Func2);
            case 3: return new GroundTransport("Избушка на курьих ножках", 15, 7, TransportFunction.Func3);
            case 4: return new GroundTransport("Кентавр", 20, 10, TransportFunction.Func4);
            case 5: return new AirTransport("Ступа Бабы Яги", 30, TransportFunction.Func5);
            case 6: return new AirTransport("Метла", 25, TransportFunction.Func6);
            case 7: return new AirTransport("Ковер-самолет", 20, TransportFunction.Func7);
            case 8: return new AirTransport("Летучий корабль", 25, TransportFunction.Func8);
            default: return new Transport("Неизвестный транспорт", 0);
        }
    }
    static void Main()
    {
        Console.WriteLine("Укажите дистанцию гонки:");
        int dist;

        try
        {
            dist = int.Parse(Console.ReadLine());
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        Console.WriteLine("Укажите тип гонки:\n" +
            "  1 - Для наземного транспорта\n" +
            "  2 - Для воздушного транспорта\n" +
            "  3 - Для всех типов транспорта\n"
            );

        int typeRice;

        try
        {
            typeRice = int.Parse(Console.ReadLine());
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        List<int> transports;

        Console.WriteLine("Выберите транспорт (введите номера через пробел):");

        switch (typeRice)
        {
            case 1:
            {
                transports = GetGroundTransports().ToList();
                break;
            }
            case 2:
            {
                transports = GetAirTransports().ToList();
                break;
            }
            case 3:
            {
                transports = GetTransports().ToList();
                break;
            }
            default:
            {
                Console.WriteLine("Введенные данные некорректны");
                return;
            }
        }

        List<Transport> transportsList = new List<Transport>();

        foreach (var transport in transports)
        {
            transportsList.Add(CreateTransport(transport));
        }

        RaceSimulator rs = new RaceSimulator(dist, transportsList);
        List<ResultRace> results = rs.Start();
        int i = 1;

        results.Sort(delegate(ResultRace x, ResultRace y)
        {
            return x.time.CompareTo(y.time);
        });

        foreach (var result in results)
        {
            string formatResult = $"{i}. {result.name} --- Время: {result.time} ; Кол-во остановок: {result.countRest} ";
            Console.WriteLine(formatResult);
            i++;
        }
    }
}
