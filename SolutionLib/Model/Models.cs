using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLib.Model
{
    public class Node
    {
        public int data;
        public Node rigth;
        public Node left;

        public Node(int data)
        {
            this.data = data;
        }
    }
}
