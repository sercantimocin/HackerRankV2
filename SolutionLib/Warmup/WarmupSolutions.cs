﻿using System;
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
    }
}
