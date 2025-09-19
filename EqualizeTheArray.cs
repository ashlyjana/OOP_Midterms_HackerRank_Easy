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
     * Complete the 'equalizeArray' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int equalizeArray(List<int> arr)
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();

        // Count frequency of each number
        foreach (int num in arr)
        {
            if (!freq.ContainsKey(num))
                freq[num] = 0;
            freq[num]++;
        }

        // Find the maximum frequency
        int maxFreq = freq.Values.Max();

        // Deletions = total count - max frequency
        return arr.Count - maxFreq;
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

        int result = Result.equalizeArray(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
