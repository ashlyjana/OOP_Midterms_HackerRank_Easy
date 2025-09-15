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
    // Sliding window maximum for 1D arrays
    private static void SlidingWindowMax1D(int[] input, int n, int k, int[] output)
    {
        int[] dq = new int[n];
        int head = 0, tail = -1;
        int outIdx = 0;

        for (int i = 0; i < n; i++)
        {
            while (tail >= head && input[dq[tail]] <= input[i]) tail--;
            dq[++tail] = i;
            if (dq[head] <= i - k) head++;
            if (i >= k - 1) output[outIdx++] = input[dq[head]];
        }
    }

    public static void SpecialSubcubes(int n, int[] values)
    {
        // Flatten cube indexing: idx = x + y*n + z*n*n
        int sizeN2 = n * n;

        // Preallocate big arrays once
        int[] pass1 = new int[n * n * n];    // after x pass
        int[] pass2 = new int[n * n * n];    // after y pass
        int[] tempIn = new int[n];
        int[] tempOut = new int[n];

        int[] result = new int[n + 1];

        for (int k = 1; k <= n; k++)
        {
            int size = n - k + 1;
            if (size <= 0) break;

            // Pass 1: x-axis sliding
            for (int y = 0; y < n; y++)
            {
                for (int z = 0; z < n; z++)
                {
                    int baseIdx = y * n + z * sizeN2;
                    for (int x = 0; x < n; x++)
                        tempIn[x] = values[baseIdx + x];
                    SlidingWindowMax1D(tempIn, n, k, tempOut);
                    for (int x = 0; x < size; x++)
                        pass1[baseIdx + x] = tempOut[x];
                }
            }

            // Pass 2: y-axis sliding
            for (int x = 0; x < size; x++)
            {
                for (int z = 0; z < n; z++)
                {
                    for (int y = 0; y < n; y++)
                        tempIn[y] = pass1[x + y * n + z * sizeN2];
                    SlidingWindowMax1D(tempIn, n, k, tempOut);
                    for (int y = 0; y < size; y++)
                        pass2[x + y * n + z * sizeN2] = tempOut[y];
                }
            }

            // Pass 3: z-axis sliding + count
            int count = 0;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    for (int z = 0; z < n; z++)
                        tempIn[z] = pass2[x + y * n + z * sizeN2];
                    SlidingWindowMax1D(tempIn, n, k, tempOut);
                    for (int z = 0; z < size; z++)
                        if (tempOut[z] == k) count++;
                }
            }

            result[k] = count;
        }

        // Print results
        for (int k = 1; k <= n; k++)
        {
            if (k > 1) Console.Write(" ");
            Console.Write(result[k]);
        }
        Console.WriteLine();
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine().Trim());
        for (int qi = 0; qi < q; qi++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            int[] arr = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            Result.SpecialSubcubes(n, arr);
        }
    }
}
