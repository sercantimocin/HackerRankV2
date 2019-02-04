using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLib.GreedyAlgo
{
    public class GreedySolutions
    {
        //Minimum Absolute Difference in an Array
        //https://www.hackerrank.com/challenges/minimum-absolute-difference-in-an-array/problem
        static int minimumAbsoluteDifference(int[] arr)
        {
            Array.Sort(arr);
            int min = Int32.MaxValue;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                min = Math.Min(Math.Abs(arr[i] - arr[i + 1]), min);
            }

            return min;
        }

        //Luck Balance
        //https://www.hackerrank.com/challenges/luck-balance/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=greedy-algorithms
        static int luckBalance(int k, int[][] contests)
        {

            int minVal = Int32.MaxValue;
            int score = 0;
            int unImportantCount = 0;

            for (int i = 0; i < contests.Length; i++)
            {
                if (contests[i][1] == 0)
                {
                    score = score + contests[i][0];
                    unImportantCount++;
                }
                contests[i][0] = contests[i][0] * contests[i][1];

            }

            for (int i = 0; i < contests.Length - 1; i++)
            {
                for (int j = i + 1; j < contests.Length; j++)
                {
                    if (contests[i][0] < contests[j][0])
                    {
                        int temp = contests[i][0];
                        contests[i][0] = contests[j][0];
                        contests[j][0] = temp;
                    }
                }
            }

            for (int i = 0; i < contests.Length - unImportantCount; i++)
            {
                if (k > 0)
                {
                    score += contests[i][0];
                    k--;
                }
                else
                {
                    score -= contests[i][0];
                }
            }
            return score;
        }

        //Greedy Florist
        //https://www.hackerrank.com/challenges/greedy-florist/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=greedy-algorithms
        static int getMinimumCost(int k, int[] c)
        {
            Array.Sort(c);

            int cost = 0;
            int initialCost = 1;
            int counter = 0;

            for (int i = c.Length - 1; i > -1; i--)
            {
                cost += (c[i] * initialCost);
                counter++;
                if ((counter) % k == 0)
                {
                    initialCost++;
                }
            }

            return cost;
        }
    }
}
