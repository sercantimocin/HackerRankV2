using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLib.HashMapAndDictionary
{
    public class HashMapSolutions
    {
        //Ransom Note
        //https://www.hackerrank.com/challenges/ctci-ransom-note/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
        static void checkMagazine(string[] magazine, string[] note)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();

            for (int j = 0; j < magazine.Length; j++)
            {
                if (words.ContainsKey(magazine[j]))
                {
                    words[magazine[j]]++;
                }
                else
                {
                    words.Add(magazine[j], 1);
                }
            }

            for (int i = 0; i < note.Length; i++)
            {
                if (words.ContainsKey(note[i]) && words[note[i]] > 0)
                {
                    words[note[i]]--;
                }
                else
                {
                    Console.Write("No");
                    return;
                }
            }

            Console.Write("Yes");
        }

        // Two Strings
        // https://www.hackerrank.com/challenges/two-strings/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
        static string twoStrings(string s1, string s2)
        {

            var c1 = new int[256];
            var c2 = new int[256];

            foreach (var c in s1)
            {
                c1[(int)c]++;
            }

            foreach (var c in s2)
            {
                c2[(int)c]++;
            }

            int counter = 0;
            for (int i = 0; i < 256; i++)
            {
                int min = Math.Min(c1[i], c2[i]);
                if (min > 0)
                {
                    counter += min;
                }
            }

            if (counter > 0)
            {
                return "YES";
            }

            return "NO";
        }

        // Sherlock and Anagrams
        //https://www.hackerrank.com/challenges/sherlock-and-anagrams/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
        public static int sherlockAndAnagrams(string s)
        {
            var chars = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (chars.ContainsKey(s[i]))
                {
                    chars[s[i]]++;
                }
                else
                {
                    chars.Add(s[i], 1);
                }
            }

            int anagramCount = 0;

            for (int i = 0; i < chars.Count; i++)
            {
                int val = chars.ElementAt(i).Value;

                if (val > 1)
                {
                    anagramCount += combination(val, 2);
                }
            }

            var subStrs = new List<string>();

            for (int i = 2; i < s.Length; i++)
            {
                for (int j = 0; j <= s.Length - i; j++)
                {
                    subStrs.Add(s.Substring(j, i));
                }
            }

            for (int i = 0; i < subStrs.Count - 1; i++)
            {
                for (int j = i + 1; j < subStrs.Count; j++)
                {
                    if (isAnagram(subStrs[i], subStrs[j]))
                    {
                        anagramCount++;
                    }
                }
            }

            return anagramCount;
        }

        static int combination(int n, int r)
        {
            if (n == r)
            {
                return 1;
            }

            if (n == (r + 1))
            {
                return n;
            }

            int dividend = 1;
            for (int i = n; i > (n - r); i--)
            {
                dividend *= i;
            }

            int divider = 1;
            for (int i = 2; i <= r; i++)
            {
                divider *= i;
            }

            return dividend / divider;
        }

        static bool isAnagram(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            var c1 = new int[26];
            var c2 = new int[26];

            for (int i = 0; i < s1.Length; i++)
            {
                c1[s1[i] - 'a']++;
                c2[s2[i] - 'a']++;
            }

            for (int i = 0; i < 26; i++)
            {
                if (c1[i] != c2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
