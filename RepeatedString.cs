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
     * Complete the 'repeatedString' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. LONG_INTEGER n
     */
    public static long repeatedString(string s, long n)
    {
        long countInS = s.Count(c => c == 'a'); // count 'a' in s
        long fullRepeats = n / s.Length;        // how many full times s fits in n
        long remainder = n % s.Length;          // leftover chars

        long total = countInS * fullRepeats;

        // count 'a' in remainder part
        for (int i = 0; i < remainder; i++)
        {
            if (s[i] == 'a')
            {
                total++;
            }
        }

        return total;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();
        long n = Convert.ToInt64(Console.ReadLine().Trim());

        long result = Result.repeatedString(s, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
