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
     * Complete the 'kaprekarNumbers' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER p
     *  2. INTEGER q
     */
    public static void kaprekarNumbers(int p, int q)
    {
        List<int> kaprekars = new List<int>();

        for (int n = p; n <= q; n++)
        {
            long sq = (long)n * n;
            string s = sq.ToString();
            int d = n.ToString().Length;

            // Right side: last d digits
            string rStr = s.Length >= d ? s.Substring(s.Length - d) : s;
            string lStr = s.Length > d ? s.Substring(0, s.Length - d) : "0";

            long left = string.IsNullOrEmpty(lStr) ? 0 : long.Parse(lStr);
            long right = string.IsNullOrEmpty(rStr) ? 0 : long.Parse(rStr);

            if (left + right == n)
            {
                kaprekars.Add(n);
            }
        }

        if (kaprekars.Count == 0)
        {
            Console.WriteLine("INVALID RANGE");
        }
        else
        {
            Console.WriteLine(string.Join(" ", kaprekars));
        }
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int p = Convert.ToInt32(Console.ReadLine().Trim());
        int q = Convert.ToInt32(Console.ReadLine().Trim());

        Result.kaprekarNumbers(p, q);
    }
}
