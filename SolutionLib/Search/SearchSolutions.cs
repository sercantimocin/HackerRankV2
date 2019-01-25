using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolutionLib.Model;
using SolutionLib.Tree;

namespace SolutionLib.Search
{
    public class SearchSolutions
    {
        //Hash Tables: Ice Cream Parlor
        //https://www.hackerrank.com/challenges/ctci-ice-cream-parlor/problem
        static void whatFlavors(int[] cost, int money)
        {
            var indexMap = new Dictionary<int, int>();

            for (int i = 0; i < cost.Length - 1; i++)
            {
                for (int j = i + 1; j < cost.Length; j++)
                {
                    if (cost[i] > cost[j])
                    {
                        int temp = cost[i];
                        cost[i] = cost[j];
                        cost[j] = temp;

                        if (indexMap.ContainsKey(i))
                        {
                            indexMap[i] = j;
                        }
                        else
                        {
                            indexMap.Add(i, j);
                        }
                    }
                }
            }

            for (int i = 0; i < cost.Length - 1; i++)
            {
                for (int j = i + 1; j < cost.Length; j++)
                {
                    int tempSum = cost[i] + cost[j];
                    if (money == tempSum)
                    {
                        int x = indexMap.ContainsKey(i) ? indexMap[i] : i;
                        int y = indexMap.ContainsKey(j) ? indexMap[j] : j;

                        Console.Write(x + 1);
                        Console.Write(" ");
                        Console.WriteLine(y + 1);
                        return;
                    }
                }
            }
        }

        /*
        static void whatFlavors(int[] cost, int money)
        {

            var results = new Dictionary<int, int>();
            int maxSum = Int32.MinValue;
            int maxI = 0, maxJ = 0;

            for (int i = 0; i < cost.Length - 1; i++)
            {
                for (int j = i + 1; j < cost.Length; j++)
                {

                    int tempSum = cost[i] + cost[j];

                    if (money == tempSum)
                    {
                        Console.Write(i + 1);
                        Console.Write(" ");
                        Console.WriteLine(j + 1);
                        return;
                    }
                    else if (money > tempSum && maxSum < tempSum)
                    {
                        maxSum = tempSum;
                        maxI = i;
                        maxJ = j;
                    }
                }
            }

            Console.Write(maxI + 1);
            Console.Write(" ");
            Console.WriteLine(maxJ + 1);
        }


        static void whatFlavors(int[] cost, int money)
        {

            int minCost = cost[0];
            int minInd = 0;
            for (int i = 1; i < cost.Length; i++)
            {
                if (minCost > cost[i])
                {
                    minCost = cost[i];
                    minInd = i;
                }
            }

            while (true)
            {
                for (int i = 0; i < cost.Length; i++)
                {
                    if (i != minInd)
                    {
                        int tempSum = cost[i] + minCost;
                        if (money == tempSum)
                        {
                            if (minInd < i)
                            {
                                Console.Write(minInd + 1);
                                Console.Write(" ");
                                Console.WriteLine(i + 1);
                            }
                            else
                            {
                                Console.Write(i + 1);
                                Console.Write(" ");
                                Console.WriteLine(minInd + 1);
                            }

                            return;
                        }
                    }
                }

                int minLimitCost = minCost + 1;
                minCost = Int32.MaxValue;
                for (int i = 0; i < cost.Length; i++)
                {
                    if (minLimitCost <= cost[i] && minCost > cost[i])
                    {
                        minCost = cost[i];
                        minInd = i;
                    }
                }
            }
        }
        */

        // Swap Nodes [Algo]
        //https://www.hackerrank.com/challenges/swap-nodes-algo/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=search
        static int[][] swapNodes(int[][] indexes, int[] queries)
        {
            var root = new Node(1);
            Queue<Node> parentQueue = new Queue<Node>();
            parentQueue.Enqueue(root);
            int row = 0;
            int nodeCount = 0;

            while (parentQueue.Count > 0)
            {
                var parent = parentQueue.Dequeue();
                nodeCount++;

                int lData = indexes[row][0];
                if (lData != -1)
                {
                    parent.left = new Node(lData);
                    parentQueue.Enqueue(parent.left);
                }

                int rData = indexes[row][1];
                if (rData != -1)
                {
                    parent.right = new Node(rData);
                    parentQueue.Enqueue(parent.right);
                }

                row++;
            }

            var temp = new LinkedList<object>();
            var result = new int[queries.Length][];

            for (int q = 0; q < queries.Length; q++)
            {
                result[q] = new int[nodeCount];
                temp.AddFirst(new KeyValuePair<Node, int>(root, 1));
                int itemCount = 0;

                while (temp.Count > 0)
                {
                    var item = temp.First();
                    temp.RemoveFirst();

                    if (item is KeyValuePair<Node, int>)
                    {
                        var i = (KeyValuePair<Node, int>)item;
                        Node node = i.Key;
                        if (node != null)
                        {
                            int nodeDepth = i.Value;
                            int depth = queries[q];

                            if (nodeDepth % depth == 0)
                            {
                                Node t = node.left;
                                node.left = node.right;
                                node.right = t;
                            }

                            temp.AddFirst(new KeyValuePair<Node, int>(node.right, nodeDepth + 1));
                            temp.AddFirst(node.data);
                            temp.AddFirst(new KeyValuePair<Node, int>(node.left, nodeDepth + 1));
                        }
                    }
                    else
                    {
                        result[q][itemCount] = (int)item;
                        itemCount++;
                    }
                }
            }

            return result;
        }
    }
}
