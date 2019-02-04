using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLib.Warmup
{
    public static class WarmupSolutions
    {
        //https://www.hackerrank.com/challenges/sock-merchant/problem
        static int sockMerchant(int n, int[] ar)
        {
            var map = new Dictionary<int, int>();

            foreach (int item in ar)
            {
                if (map.ContainsKey(item))
                {
                    map[item]++;
                }
                else
                {
                    map.Add(item, 1);
                }
            }

            int count = 0;
            foreach (var m in map)
            {
                count += (m.Value / 2);
            }

            return count;
        }

        //https://www.hackerrank.com/challenges/counting-valleys/problem
        static int countingValleys(int n, string s)
        {

            int depth = 0;
            int count = 0;

            foreach (char c in s)
            {
                if (c == 'U')
                {
                    depth++;
                    if (depth == 0)
                    {
                        count++;
                    }
                }
                else
                {
                    depth--;
                }
            }

            return count;
        }

        //https://www.hackerrank.com/challenges/jumping-on-the-clouds/problem
        static int jumpingOnClouds(int[] c)
        {
            int current = 0;
            int stepCount = 0;
            while (current < c.Length - 1)
            {
                int doubleStep = current + 2;

                if (doubleStep < c.Length && c[doubleStep] == 0)
                {
                    current = doubleStep;
                }
                else
                {
                    current++;
                }

                stepCount++;
            }

            return stepCount;
        }
    }
}
