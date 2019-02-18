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
        //Balanced Brackets
        //https://www.hackerrank.com/challenges/balanced-brackets/problem
        static string isBalanced(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                if (c == '{' || c == '(' || c == '[')
                {
                    stack.Push(c);
                }

                if (c == '}')
                {
                    if (stack.Count == 0)
                    {
                        return "NO";
                    }

                    var pairChar = stack.Pop();
                    if (pairChar != '{')
                    {
                        return "NO";
                    }
                }

                if (c == ')')
                {
                    if (stack.Count == 0)
                    {
                        return "NO";
                    }

                    var pairChar = stack.Pop();
                    if (pairChar != '(')
                    {
                        return "NO";
                    }
                }

                if (c == ']')
                {
                    if (stack.Count == 0)
                    {
                        return "NO";
                    }

                    var pairChar = stack.Pop();
                    if (pairChar != '[')
                    {
                        return "NO";
                    }
                }
            }

            if (stack.Count > 0)
            {
                return "NO";
            }

            return "YES";
        }

        //Queues: A Tale of Two Stacks
        //https://www.hackerrank.com/challenges/ctci-queue-using-two-stacks/problem

        //https://www.hackerrank.com/challenges/castle-on-the-grid/problem
        public static int minimumMoves(string[] grid, int startX, int startY, int goalX, int goalY)
        {
            int n = grid.GetLength(0);
            Stack<string> path = new Stack<string>();
            bool isXPath = true;

            while ((startX == goalX && startY == goalY) == false)
            {
                if (isXPath)
                {
                    int diffX = goalX - startX;
                    if (diffX == 0)
                    {
                        isXPath = false;
                        continue;
                    }

                    if (diffX > 0)
                    {
                        startX++;
                        path.Push("E");
                    }
                    else
                    {
                        startX--;
                        path.Push("W");
                    }

                    var current = grid[startY][startX];
                    if (current == 'X' || startX < 0 || startX >= n)
                    {
                        path.Pop();
                        isXPath = false;
                    }
                }
                else
                {
                    int diffY = goalY - startY;

                    if (diffY == 0)
                    {
                        isXPath = true;
                        continue;
                    }

                    if (diffY > 0)
                    {
                        startY++;
                        path.Push("N");
                    }
                    else
                    {
                        startY--;
                        path.Push("S");
                    }

                    var current = grid[startY][startX];
                    if (current == 'X' || startY < 0 || startY >= n)
                    {
                        path.Pop();
                        isXPath = true;
                    }
                }
            }

            string lastChr = path.Pop(); 
            string currentChr = lastChr;
            int counter = 0;
            while (path.Count > 0)
            {
                lastChr = currentChr;
                currentChr = path.Pop();

                if (lastChr != currentChr )
                {
                    counter++;
                }
            }

            return counter;
        }

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
