using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLib.DynamicProgramming
{
    public class DynamicProgSolutions
    {
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
            int max = Int32.MinValue;

            for (int i = 0; i < arr.Length - 2; i++)
            {
                int prev = i + 2;
                int next = prev + 2;
                int temp = arr[i] + arr[prev];
                string key = $"{i}{prev}";

                if (!storage.ContainsKey(key))
                {
                    storage.Add(key, temp);
                }

                if (temp > max)
                {
                    max = temp;
                }

                while (prev < arr.Length && next < arr.Length)
                {
                    int t = storage[key] + arr[next];
                    if (t > max)
                    {
                        max = t;
                    }

                    string newKey = $"{key}{next}";
                    if (!storage.ContainsKey(newKey))
                    {
                        storage.Add(newKey, t);
                    }

                    next++;
                    if (next >= arr.Length)
                    {
                        prev++;
                        next = prev + 2;
                    }

                }
            }

            return max;
        }
    }
}
