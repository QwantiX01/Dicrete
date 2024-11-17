using static Combinatorics.Comb.Sorting;

namespace Combinatorics.Comb;

public static class Comb
{
    public static long A(int n, int k)
    {
        return Factorial(n) / Factorial(n - k);
    }

    public static long C(int n, int k)
    {
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }

    public static long Factorial(int n)
    {
        long result = 1;
        for (long i = 2; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }

    public static long _A(int n, int k)
    {
        return (long)Math.Pow(n, k);
    }

    public static long _C(int n, int k)
    {
        return Factorial(n + k - 1) / (Factorial(k) * Factorial(n - 1));
    }

    public static int[] GenPerm(int[] ints)
    {
        for (int i = 1; i <= ints.Length; i++)
        {
            if (i < ints.Length)
                if (ints[^(i + 1)] < ints[^i])
                {
                    var min = ints[^i..][0];
                    foreach (var k in ints[^i..])
                        if (k < min && k > ints[^(i + 1)])
                            min = k;
                    var indexOfMin = ints.ToList().IndexOf(min);
                    (ints[^(i + 1)], ints[indexOfMin]) = (ints[indexOfMin], ints[^(i + 1)]);
                    SortInsertion(ints, ints.Length - i, ints.Length - 1);
                    break;
                }
        }

        return ints;
    }
}