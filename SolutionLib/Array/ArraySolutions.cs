﻿using System;
using System.Collections.Generic;

public class ArraySolutions
{
    //2D Array - DS
    //https://www.hackerrank.com/challenges/2d-array/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays
    static int hourglassSum(int[][] arr)
    {
        int bestSum = int.MinValue;

        for (int c = 0; c < 4; c++)
        {
            for (int r = 0; r < 4; r++)
            {
                int firstRowSum = arr[r][c] + arr[r][c + 1] + arr[r][c + 2];
                int secondRowSum = arr[r + 1][c + 1];
                int thirdRowSum = arr[r + 2][c] + arr[r + 2][c + 1] + arr[r + 2][c + 2];

                int hourGlassSum = firstRowSum + secondRowSum + thirdRowSum;

                if (bestSum < hourGlassSum)
                {
                    bestSum = hourGlassSum;
                }
            }
        }

        return bestSum;
    }

    //Arrays: Left Rotation
    //https://www.hackerrank.com/challenges/ctci-array-left-rotation/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays
    static int[] rotLeft(int[] a, int d)
    {

        int i = d;
        int[] result = new int[a.Length];

        for (int j = 0; j < a.Length; j++)
        {
            i = i % a.Length;
            result[j] = a[i];
            i++;
        }

        return result;
    }

    //V1
    static int minimumSwapsV1(int[] arr)
    {

        int swapCount = 0;
        int min = Int32.MaxValue;
        int minIndex = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
                minIndex = i;
            }
        }

        if (minIndex > 0)
        {
            int t = arr[0];
            arr[0] = arr[minIndex];
            arr[minIndex] = t;
            swapCount++;
        }

        for (int i = 1; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] == min + i)
                {
                    if (j != i)
                    {
                        int t = arr[i];
                        arr[i] = arr[j];
                        arr[j] = t;
                        swapCount++;
                    }
                }
            }
        }

        return swapCount;
    }

    // Mininum Swaps 2 V2
    // https://www.hackerrank.com/challenges/minimum-swaps-2/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays
    static int minimumSwaps(int[] arr)
    {

        int swapCount = 0;
        int min = Int32.MaxValue;
        int minIndex = -1;
        var arrDic = new Dictionary<int, int>();

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
                minIndex = i;
            }
            arrDic.Add(arr[i], i);
        }

        if (minIndex > 0)
        {
            int t = arr[0];
            arr[0] = arr[minIndex];
            arr[minIndex] = t;
            swapCount++;
            arrDic[arr[minIndex]] = minIndex;
        }

        for (int i = 1; i < arr.Length - 1; i++)
        {
            int j = arrDic[min + i];

            if (j != i)
            {
                int t = arr[i];
                arr[i] = arr[j];
                arr[j] = t;
                swapCount++;
                arrDic[arr[j]] = j;
            }
        }

        return swapCount;
    }

    // v1 More complex
    //https://www.hackerrank.com/challenges/new-year-chaos/problem
    static void minimumBribes(int[] q)
    {
        int bribeCount = 0;
        int findNum = q.Length;
        int expectedIndex = findNum - 1;

        while (findNum > 0)
        {
            int actualIndex = findInArray(q, findNum);

            if (actualIndex == expectedIndex)
            {
                findNum--;
                expectedIndex--;
            }
            else
            {
                if (Math.Abs(expectedIndex - actualIndex) > 2)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }

                while (actualIndex != expectedIndex)
                {
                    int t = q[actualIndex];
                    q[actualIndex] = q[actualIndex + 1];
                    q[actualIndex + 1] = t;
                    actualIndex++;
                    bribeCount++;
                }
            }
        }

        Console.WriteLine(bribeCount);
    }

    static int findInArray(int[] q, int findNum)
    {
        for (int i = q.Length - 1; i >= 0; i--)
        {
            if (findNum == q[i])
            {
                return i;
            }
        }

        return -1;
    }

    //v2 More complex
    //https://www.hackerrank.com/challenges/new-year-chaos/problem
    public static void minimumBribes2(int[] q)
    {
        int bribeCount = 0;
        int findNum = q.Length;
        int expectedIndex = findNum - 1;

        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int j = 0; j < q.Length; j++)
        {
            map.Add(q[j], j);
        }

        while (findNum > 0)
        {
            int actualIndex = map[findNum];

            if (actualIndex == expectedIndex)
            {
                findNum--;
                expectedIndex--;
            }
            else
            {
                if (Math.Abs(expectedIndex - actualIndex) > 2)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }

                while (actualIndex != expectedIndex)
                {
                    map[q[actualIndex + 1]]--;
                    map[q[actualIndex]]++;

                    int t = q[actualIndex];
                    q[actualIndex] = q[actualIndex + 1];
                    q[actualIndex + 1] = t;

                    actualIndex++;
                    bribeCount++;
                }

                findNum--;
                expectedIndex--;
            }
        }

        Console.WriteLine(bribeCount);
    }

    /*
    int ans = 0;
    for (int i = q.size() - 1; i >= 0; i--) {
        if (q[i] - (i + 1) > 2) {
            cout << "Too chaotic" << endl;
            return;
        }
        for (int j = max(0, q[i] - 2); j < i; j++)
            if (q[j] > q[i]) ans++;
    }
    cout << ans << endl;
     */

    //Brute Force
    //https://www.hackerrank.com/challenges/crush/problem
    static long arrayManipulation(int n, int[][] queries)
    {
        var temp = new int[n];
        for (int i = 0; i < queries.GetLength(0); i++)
        {
            for (int j = queries[i][0] - 1; j <= queries[i][1] - 1; j++)
            {
                temp[j] += queries[i][2];
            }
        }

        int max = Int32.MinValue;

        for (int j = 0; j < n; j++)
        {
            max = Math.Max(temp[j], max);
        }

        return max;
    }
}
