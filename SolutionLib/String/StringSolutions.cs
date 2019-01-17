using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLib.String
{
    public class StringSolutions
    {
        //https://www.hackerrank.com/challenges/sherlock-and-valid-string/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=strings
        public static string isValid(string s)
        {
            var freq = new Dictionary<char, int>();
            int maxFreq = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (freq.ContainsKey(s[i]))
                {
                    freq[s[i]]++;

                    if (maxFreq < freq[s[i]])
                    {
                        maxFreq = freq[s[i]];
                    }
                }
                else
                {
                    freq.Add(s[i], 1);
                }
            }

            if (freq.Count == 0)
            {
                return "NO";
            }

            int zeroCount = 0;
            var depths = new int[freq.Count];

            for (int i = 0; i < freq.Count; i++)
            {
                var item = freq.ElementAt(i);
                var diff = item.Value - maxFreq;
                depths[i] = diff;

                if (diff == 0)
                {
                    zeroCount++;
                }
            }

            if (zeroCount == freq.Count)
            {
                return "YES";
            }
            else if (zeroCount == 1)
            {
                int count = 0;
                for (int i = 0; i < freq.Count; i++)
                {
                    if (depths[i] > -1)
                    {
                        count++;
                    }

                    if (count > 1)
                    {
                        return "NO";
                    }
                }

                return "YES";
            }
            else if (zeroCount == (freq.Count - 1))
            {
                int i;
                for (i = 0; i < freq.Count; i++)
                {
                    if (depths[i] != null)
                    {
                        break;
                    }
                }

                if (freq.ElementAt(i).Value == 1)
                {
                    return "YES";
                }

                return "NO";
            }
            else
            {
                return "NO";
            }
        }
    }
}
