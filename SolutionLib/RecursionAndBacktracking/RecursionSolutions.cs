using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLib.RecursionAndBacktracking
{
    class RecursionSolutions
    {
        //Recursion: Fibonacci Numbers
        //https://www.hackerrank.com/challenges/ctci-fibonacci-numbers/problem
        public static int Fibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            int t0 = 0;
            int t1 = 1;
            int temp = t1 + t0;
            for (int i = 2; i <= n; i++)
            {

                temp = t1 + t0;
                t0 = t1;
                t1 = temp;

                if (i == n)
                {
                    return temp;
                }
            }

            return -1;
        }
    }
}
