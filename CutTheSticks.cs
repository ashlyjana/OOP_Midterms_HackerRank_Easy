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
    /*
     * Complete the 'cutTheSticks' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
    public static List<int> cutTheSticks(List<int> arr)
    {
        List<int> result = new List<int>();

        while (arr.Count > 0)
        {
            // Count current sticks
            result.Add(arr.Count);

            // Find the smallest positive stick
            int minStick = arr.Min();

            // Cut sticks and discard zeros
            arr = arr.Select(x => x - minStick).Where(x => x > 0).ToList();
        }

        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine()
            .TrimEnd()
            .Split(' ')
            .ToList()
            .Select(arrTemp => Convert.ToInt32(arrTemp))
            .ToList();

        List<int> result = Result.cutTheSticks(arr);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
