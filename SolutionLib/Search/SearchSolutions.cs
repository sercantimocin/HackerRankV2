﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolutionLib.Model;

namespace SolutionLib.Search
{
    public class SearchSolutions
    {
        static int[][] swapNodes(int[][] indexes, int[] queries)
        {

            var root = new Node(1);

            Queue<Node> parentQueue = new Queue<Node>();
            parentQueue.Enqueue(root);

            int row = 0;
            while (parentQueue.Count > 0)
            {
                var parent = parentQueue.Dequeue();

                int rData = indexes[row][0];
                int lData = indexes[row][1];

                if (rData != -1)
                {
                    parent.right = new Node(rData);
                    parentQueue.Enqueue(parent.right);
                }

                if (lData != -1)
                {
                    parent.left = new Node(lData);
                    parentQueue.Enqueue(parent.left);
                }
            }

            //Node current = root;
            //int currentDepth = 1;

            //while (current != null)
            //{
            //    current
            //    current.left
            //}



            //int i = 0;
            //int j = 0;
            //int depth = queries[i];
            //int currentDepth = 0;

            //LinkedList<object> list = new LinkedList<object>();
            //list.AddFirst(root);


            //while (list.Count > 0)
            //{
            //    var parent = list.First;
            //    list.RemoveFirst();
            //    currentDepth++;

            //    if (parent is Node)
            //    {
            //        if (currentDepth == depth)
            //        {
            //            var temp = parent.left;
            //            parent.left = parent.rigth;
            //            parent.rigth = temp;
            //        }

            //        parent.AddFirst(current.left);
            //        parent.AddFirst(current);
            //        parent.AddFirst(current.right);
            //    }
            //    else
            //    {
            //        currentDepth--;

            //        indexes[i][j] = parent as int;
            //        j++;
            //    }
            //}



            return indexes;
        }

        public static int[][] swapNodes2(int[][] indexes, int[] queries)
        {
            var root = new Node(1);

            Queue<Node> parentQueue = new Queue<Node>();
            parentQueue.Enqueue(root);

            int row = 0;
            while (parentQueue.Count > 0)
            {
                var parent = parentQueue.Dequeue();

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
            }

            var temp = new LinkedList<KeyValuePair<Node, int>>();
            temp.AddFirst(new KeyValuePair<Node, int>(root, 1));
            int itemCount = 0;

            for (int q = 0; q < queries.Length; q++)
            {
                while (temp.Count > 0)
                {
                    KeyValuePair<Node, int> item = temp.First();
                    temp.RemoveFirst();

                    Node node = item.Key;
                    if (node != null)
                    {
                        int nodeDepth = item.Value;
                        int depth = queries[q];

                        if (nodeDepth == depth)
                        {
                            Node t = node.left;
                            node.left = node.right;
                            node.right = t;
                        }

                        temp.AddFirst(new KeyValuePair<Node, int>(node.right, ++nodeDepth));
                        temp.AddFirst(new KeyValuePair<Node, int>(node.left, ++nodeDepth));

                        indexes[q][itemCount] = node.data;
                        itemCount++;
                    }
                }
            }

            return indexes;
        }
    }
}
