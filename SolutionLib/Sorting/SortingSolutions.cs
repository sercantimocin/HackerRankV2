using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLib.Sorting
{
    class SortingSolutions
    {
        //Sorting: Bubble Sort
        // https://www.hackerrank.com/challenges/ctci-bubble-sort/problem
        static void countSwaps(int[] a)
        {

            int swapCount = 0;

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        int temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                        swapCount++;
                    }
                }
            }

            Console.WriteLine($"Array is sorted in {swapCount} swaps.");
            Console.WriteLine("First Element: {0}", a[0]);
            Console.WriteLine("Last Element: {0}", a[a.Length - 1]);
        }

        //Mark and Toys
        //https://www.hackerrank.com/challenges/mark-and-toys/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=sorting
        static int maximumToys(int[] prices, int k)
        {
            Array.Sort(prices);

            int i = 0;
            int count = 0;
            while (k > 0 && i < prices.Length)
            {
                if (prices[i] > k)
                {
                    break;
                }
                else
                {
                    k -= prices[i];
                    count++;
                }

                i++;
            }

            return count;
        }

        //Sorting: Comparator
        //https://www.hackerrank.com/challenges/ctci-comparator-sorting/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=sorting
        static int comparator(Player a, Player b)
        {
            if (a.score < b.score)
            {
                return -1;
            }
            else if (a.score > b.score)
            {
                return 1;
            }
            else
            {
                //int minLength = std::min(a.name.length(), b.name.length()); //C++ version
                int minLength = Math.Min(a.name.Length, b.name.Length);

                for (int i = 0; i < minLength; i++)
                {
                    if (a.name[i] == b.name[i])
                    {
                        continue;
                    }
                    else
                    {
                        if (((int)a.name[i] - (int)b.name[i]) < 0)
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }

                //if (a.name.length() > b.name.length()) //C++ version
                if (a.name.Length > b.name.Length)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }

            }

            return 0;
        }

        public struct Player
        {
            public int score;
            public string name;
        };
    }
}
