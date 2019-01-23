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
        //For self training
        public static List<int> depthFirstTraversal(Node root)
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
                    queue.Enqueue(current.rigth);
                    queue.Enqueue(current.left);
                }
            }

            return list;
        }
    }
}
