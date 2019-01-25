using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLib.Stack
{
    public class StackSolutions
    {
        //Queues: A Tale of Two Stacks
        //https://www.hackerrank.com/challenges/ctci-queue-using-two-stacks/problem
        public class MyQueue<T>
        {
            Stack<T> stackNewestOnTop = new Stack<T>();
            Stack<T> stackOldestOnTop = new Stack<T>();

            public void enqueue(T value)
            {
                stackNewestOnTop.Push(value);
            }

            public T peek()
            {
                if (stackOldestOnTop.Count == 0)
                {
                    while (stackNewestOnTop.Count > 0)
                    {
                        var item = stackNewestOnTop.Pop();
                        stackOldestOnTop.Push(item);
                    }
                }

                return stackOldestOnTop.Peek();
            }

            public void dequeue()
            {
                if (stackOldestOnTop.Count == 0)
                {
                    while (stackNewestOnTop.Count > 0)
                    {
                        var item = stackNewestOnTop.Pop();
                        stackOldestOnTop.Push(item);
                    }
                }

                if (stackOldestOnTop.Count > 0)
                {
                    stackOldestOnTop.Pop();
                }
            }

            //static void Main(System.String[] args)
            //{
            //    MyQueue<int> queue = new MyQueue<int>();

            //    var scan = Console.ReadLine();
            //    int n = Convert.ToInt32(scan);

            //    for (int i = 0; i < n; i++)
            //    {
            //        var inputs = Console.ReadLine().Split(' ');
            //        int operation = Convert.ToInt32(inputs[0]);
            //        if (operation == 1)
            //        { // enqueue
            //            queue.enqueue(Convert.ToInt32(inputs[1]));
            //        }
            //        else if (operation == 2)
            //        { // dequeue
            //            queue.dequeue();
            //        }
            //        else if (operation == 3)
            //        {
            //            Console.WriteLine(queue.peek());
            //        }
            //    }
            //}
        }
    }
}
