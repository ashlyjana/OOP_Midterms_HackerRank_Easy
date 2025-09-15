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
     * Complete the 'specialSubCubes' function below.
     *
     * The function accepts following parameters:
     *  1. int n -> cube side length
     *  2. List<int> values -> list of n^3 integers
     *
     * The function prints the count of special sub-cubes for each size.
     */
    public static void specialSubCubes(int n, List<int> values)
    {
        // Build the 3D cube from the list
        int[,,] cube = new int[n, n, n];
        int idx = 0;
        for (int x = 0; x < n; x++)
        {
            for (int y = 0; y < n; y++)
            {
                for (int z = 0; z < n; z++)
                {
                    cube[x, y, z] = values[idx++];
                }
            }
        }

        // Get maximum value in the whole cube
        int globalMax = values.Max();

        // For each k (sub-cube size)
        List<int> result = new List<int>();
        for (int k = 1; k <= n; k++)
        {
            int count = 0;
            // Iterate over all possible starting points for a k x k x k cube
            for (int x = 0; x <= n - k; x++)
            {
                for (int y = 0; y <= n - k; y++)
                {
                    for (int z = 0; z <= n - k; z++)
                    {
                        int localMax = int.MinValue;
                        for (int i = 0; i < k; i++)
                        {
                            for (int j = 0; j < k; j++)
                            {
                                for (int l = 0; l < k; l++)
                                {
                                    localMax = Math.Max(localMax, cube[x + i, y + j, z + l]);
                                }
                            }
                        }
                        if (localMax == globalMax)
                        {
                            count++;
                        }
                    }
                }
            }
            result.Add(count);
        }

        Console.WriteLine(string.Join(" ", result));
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int t = 0; t < q; t++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> values = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            Result.specialSubCubes(n, values);
        }
    }
}
