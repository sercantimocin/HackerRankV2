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
