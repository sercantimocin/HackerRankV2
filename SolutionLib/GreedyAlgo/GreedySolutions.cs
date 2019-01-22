using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLib.GreedyAlgo
{
    public class GreedySolutions
    {
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
