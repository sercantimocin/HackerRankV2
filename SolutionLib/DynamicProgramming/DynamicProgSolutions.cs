using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLib.DynamicProgramming
{
    public class DynamicProgSolutions
    {
        // Tekrar çöz brute force hali
        //https://www.hackerrank.com/challenges/max-array-sum/problem
        public static int maxSubsetSum(int[] arr)
        {
            if (arr.Length == 0)
            {
                return 0;
            }

            if (arr.Length == 1)
            {
                return arr[0];
            }

            var storage = new Dictionary<string, int>();
            int max = int.MinValue;

            int k1 = 0;
            int k2 = k1 + 2;
            int k3 = k2 + 2;

            while (k1 < arr.Length)
            {
                int temp = arr[k1] + arr[k2];
                string key1 = $"{k1}{k2}";

                if (!storage.ContainsKey(key1))
                {
                    storage.Add(key1, temp);
                }

                if (temp > max)
                {
                    max = temp;
                }

                if (k3 < arr.Length)
                {
                    string key2 = $"{key1}{k3}";
                    temp = storage[key1] + arr[k3];

                    if (!storage.ContainsKey(key2))
                    {
                        storage.Add(key2, temp);
                    }

                    if (temp > max)
                    {
                        max = temp;
                    }
                }

                k3++;

                if (k3 >= arr.Length)
                {
                    k2++;
                    k3 = k2 + 2;
                }

                if (k2 >= arr.Length)
                {
                    k1++;
                    k2 = k1 + 2;
                    k3 = k2 + 2;
                }

                if (k2 >= arr.Length)
                {
                    break;
                }
            }

            return max;
        }
    }
}
