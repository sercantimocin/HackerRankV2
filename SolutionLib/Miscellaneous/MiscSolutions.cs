using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLib.Miscellaneous
{
    class MiscSolutions
    {
        //Flipping bits
        //https://www.hackerrank.com/challenges/flipping-bits/problem
        static long flippingBits(long n)
        {
            long max = 4294967295;

            return max - n;
        }
    }
}
