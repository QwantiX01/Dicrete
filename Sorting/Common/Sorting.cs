namespace Sorting.Common;

public static class Sorting
{
    public static int[] SortBubble(int[] numbers, int startIndex, int endIndex)
    {
        for (var i = startIndex; i < endIndex + 1; i++)
            for (var j = startIndex; j <= endIndex; j++)
                if (numbers[j] > numbers[j + 1])
                    Swap(ref numbers[j], ref numbers[j + 1]);
        return numbers;
    }

    public static int[] SortInsertion(int[] numbers, int startIndex, int endIndex)
    {
        if (startIndex == endIndex)
        {
            return numbers;
        }
        if (startIndex < 0 || endIndex >= numbers.Length || startIndex >= endIndex)
        {
            throw new ArgumentOutOfRangeException("Invalid start or end index.");
        }
        for (var i = startIndex + 1; i <= endIndex; i++)
        {
            var j = i;
            while (j > startIndex && numbers[j - 1] > numbers[j])
            {
                Swap(ref numbers[j], ref numbers[j - 1]);
                j--;
            }
        }
        return numbers;
    }

    public static int[] SortSelection(int[] numbers, int startIndex, int endIndex)
    {
        for (var i = startIndex; i < endIndex; i++)
        {
            var minIndex = i;
            for (var j = i + 1; j <= endIndex + 1; j++)
                if (numbers[j] < numbers[minIndex])
                    minIndex = j;
            Swap(ref numbers[i], ref numbers[minIndex]);
        }

        return numbers;
    }

    private static void Swap(ref int a, ref int b) => (a, b) = (b, a);

    public static int Min(int[] numbers)
    {
        var min = numbers[0];
        foreach (var t in numbers)
            if (t < min)
                min = t;

        return min;
    }

    public static int Max(int[] numbers)
    {
        var max = numbers[0];
        foreach (var t in numbers)
            if (t > max)
                max = t;

        return max;
    }
}