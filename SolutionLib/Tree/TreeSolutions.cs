using System;
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


        //For self training
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
    }
}
