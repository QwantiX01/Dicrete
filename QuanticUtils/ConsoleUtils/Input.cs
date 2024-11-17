namespace QuanticUtils.ConsoleUtils;

public static class Input
{
    public static double GetNumber()
    {
        double result;
        while (true)
        {
            var stringBuffer = Console.ReadLine();
            if (double.TryParse(stringBuffer, out result))
                break;
        }

        return result;
    }
}