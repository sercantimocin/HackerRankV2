﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolutionLib.Model;
using SolutionLib.Search;

namespace SolutionLib.Tree
{
    public class TreeSolutions
    {
        /*
         * What are BFS and DFS for Binary Tree?
            A Tree is typically traversed in two ways:

            Breadth First Traversal (Or Level Order Traversal)
            Depth First Traversals
            Inorder Traversal (Left-Root-Right)
            Preorder Traversal (Root-Left-Right)
            Postorder Traversal (Left-Right-Root)

            Example Tree
                     1
                  2    3
                4   5
            BFS and DFSs of above Tree

            Breadth First Traversal : 1 2 3 4 5

            Depth First Traversals:
                  Preorder Traversal : 1 2 4 5 3 
                  Inorder Traversal  :  4 2 5 1 3 
                  Postorder Traversal : 4 5 2 3 1
         */

        public static List<int> BreadthFirstTraversal(Node root)
        {
            if (root == null)
            {
                return null;
            }

            var list = new List<int>();
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                if (current != null)
                {
                    list.Add(current.data);
                    queue.Enqueue(current.left);
                    queue.Enqueue(current.right);
                }
            }

            return list;
        }

        public static List<int> PreOrderTraversal(Node root)
        {
            if (root == null)
            {
                return null;
            }

            var list = new List<int>();
            var temp = new Stack<Node>();
            temp.Push(root);

            while (temp.Count > 0)
            {
                Node current = temp.Pop();

                if (current != null)
                {
                    list.Add(current.data);
                    temp.Push(current.right);
                    temp.Push(current.left);
                }
            }

            return list;
        }

        public static List<int> InOrderTraversal(Node root)
        {
            if (root == null)
            {
                return null;
            }

            var list = new List<int>();
            var temp = new LinkedList<object>();
            temp.AddFirst(root);

            while (temp.Count > 0)
            {
                var current = temp.First();
                temp.RemoveFirst();

                if (current != null)
                {
                    if (current is Node)
                    {
                        var n = current as Node;
                        temp.AddFirst(n.right);
                        temp.AddFirst(n.data);
                        temp.AddFirst(n.left);
                    }
                    else
                    {
                        list.Add((int)current);
                    }
                }
            }

            return list;
        }

        public static List<int> PostOrderTraversal(Node root)
        {
            if (root == null)
            {
                return null;
            }

            List<int> list = new List<int>();
            var temp = new LinkedList<object>();
            temp.AddFirst(root);

            while (temp.Count > 0)
            {
                var current = temp.First();
                temp.RemoveFirst();

                if (current != null)
                {
                    if (current is Node)
                    {
                        var c = current as Node;
                        temp.AddFirst(c.data);
                        temp.AddFirst(c.right);
                        temp.AddFirst(c.left);
                    }
                    else
                    {
                        list.Add((int)current);
                    }
                }
            }

            return list;
        }

        // Passed from Hackerrank
        // Valid comment out beacuse it coded with C++ 
        //https://www.hackerrank.com/challenges/tree-height-of-a-binary-tree/problem
        //int height(Node* root)
        //{
        //    if (root == NULL)
        //    {
        //        return 0;
        //    }

        //    if (root->left == NULL && root->right == NULL)
        //    {
        //        return 0;
        //    }

        //    return getHeight(root, 0) - 1;
        //}

        //int getHeight(Node* node, int height)
        //{
        //    if (node == NULL)
        //    {
        //        return height;
        //    }

        //    return std::max(getHeight(node->left, height + 1), getHeight(node->right, height + 1));
        //}

        // Same solution with above without recursion
        //https://www.hackerrank.com/challenges/tree-height-of-a-binary-tree/problem
        public static int height(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.left == null && root.right == null)
            {
                return 0;
            }

            List<Tuple<Node, int>> values = new List<Tuple<Node, int>>();
            values.Add(new Tuple<Node, int>(root, 0));
            int maxHeigth = 0;

            while (values.Count > 0)
            {
                var v = values[values.Count-1];
                Node node = v.Item1;
                int height = v.Item2;
                values.RemoveAt(values.Count - 1);

                if (node.left != null)
                {
                    values.Add(new Tuple<Node,int>(node.left, height + 1));
                }

                if (node.right != null)
                {
                    values.Add(new Tuple<Node, int>(node.right, height + 1));
                }

                maxHeigth = Math.Max(maxHeigth, height);
            }

            return maxHeigth;
        }

        // Passed from Hackerrank
        //https://www.hackerrank.com/challenges/binary-search-tree-lowest-common-ancestor/problem
        //public static Node lca(Node root, int v1, int v2)
        //{
        //    if (root == null)
        //    {
        //        return null;
        //    }

        //    Node current = root;

        //    while (true)
        //    {
        //        if (current.data == v1 || current.data == v2)
        //        {
        //            return current;
        //        }

        //        boolean v1InLeft = isInBranch(current.left, v1);
        //        boolean v2InRight = isInBranch(current.right, v2);

        //        if ((v1InLeft && v2InRight) || (v1InLeft == false && v2InRight == false))
        //        {
        //            return current;
        //        }
        //        else if (v1InLeft)
        //        {
        //            current = current.left;
        //        }
        //        else
        //        {
        //            current = current.right;
        //        }
        //    }
        //}

        //public static boolean isInBranch(Node node, int nodeVal)
        //{
        //    if (node == null)
        //    {
        //        return false;
        //    }

        //    if (node.data == nodeVal)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return isInBranch(node.left, nodeVal) || isInBranch(node.right, nodeVal);
        //    }
        //}

        // Passed from Hackerrank
        //https://www.hackerrank.com/challenges/tree-huffman-decoding/problem
        //void decode(String s, Node root)
        //{

        //    StringBuilder builder = new StringBuilder();
        //    Node current = root;

        //    for (int i = 0; i < s.length(); i++)
        //    {
        //        char c = s.charAt(i);

        //        //Move
        //        if (c == '0')
        //        {
        //            current = current.left;
        //        }
        //        else
        //        {
        //            current = current.right;
        //        }

        //        //Insert new key
        //        if (current.data != '\u0000')
        //        {
        //            builder.append(current.data);
        //            current = root;
        //        }

        //    }


        //    System.out.println(builder.toString());
        //}
    }
}
