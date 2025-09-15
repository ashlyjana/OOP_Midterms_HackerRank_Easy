using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    public static int birthdayCakeCandles(List<int> candles)
    {
        int max = candles.Max();
        int count = candles.Count(x => x == max);
        return count;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int candlesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> candles = Console.ReadLine()
                                   .Trim()
                                   .Split(' ')
                                   .Select(int.Parse)
                                   .ToList();

        int result = Result.birthdayCakeCandles(candles);

        // Works locally:
        Console.WriteLine(result);

        // On HackerRank, replace with:
        // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        // textWriter.WriteLine(result);
        // textWriter.Flush();
        // textWriter.Close();
    }
}

