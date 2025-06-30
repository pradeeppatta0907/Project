using System;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    { public static int GetFactorial(int n)
        {
            if (n < 0) 
                throw new ArgumentOutOfRangeException(nameof(n), "Factorial is not defined for negative numbers.");

            checked // ensure overflow detection
            {
                int result = 1;
                for (int i = 2; i <= n; i++)
                {
                    result *= i;
                }
                return result;
            }
        }

        public static string FormatSeparators(params string[] items)
        {
    if (items == null || items.Length == 0)
        return string.Empty;

    switch (items.Length)
    {
        case 1:
            return items[0];
        case 2:
            return $"{items[0]} and {items[1]}";
        default:
            var prefix = string.Join(", ", items, 0, items.Length - 1);
            return $"{prefix} and {items[^1]}";
    }
    }
    }
}