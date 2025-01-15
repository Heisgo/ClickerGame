using System;
using UnityEngine;

public static class NumberFormatter 
{
    private static readonly string[] Suffixes = {
        "", "k", "m", "b", "t", "q", "Q", "s", "S", "o", "n", "d", "U", "D", "T"
    };

    public static string FormatNumber(double value)
    {
        if (value < 1000) return value.ToString("0.#");

        int magnitude = (int)Math.Floor((float)Math.Log10(value) / 3);

        if (magnitude >= Suffixes.Length || magnitude < 0)
            return value.ToString("0.##e+0");
        
        double scaledValue = value / Mathf.Pow(1000, magnitude);
        string suffix = Suffixes[magnitude];

        return scaledValue.ToString("0.##") + suffix;
    }
}
