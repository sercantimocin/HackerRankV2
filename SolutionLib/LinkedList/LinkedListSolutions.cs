using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLib.LinkedList
{
    class LinkedListSolutions
    {
        //Insert a node at a specific position in a linked list
        //https://www.hackerrank.com/challenges/insert-a-node-at-a-specific-position-in-a-linked-list/problem
        static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode head, int data, int position)
        {
            var current = head;

            int p = 0;
            while (current != null)
            {

                if (p == (position - 1))
                {
                    var newNode = new SinglyLinkedListNode(data);
                    newNode.next = current.next;

                    current.next = newNode;

                    return head;
                }
                p++;
                current = current.next;
            }

            return null;
        }

        //Inserting a Node Into a Sorted Doubly Linked List
        //https://www.hackerrank.com/challenges/insert-a-node-into-a-sorted-doubly-linked-list/problem
        static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode head, int data)
        {

            var current = head.next;
            var previous = head;

            if (head.data > data)
            {
                var newNode = new DoublyLinkedListNode(data);
                newNode.prev = null;
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
                return head;
            }

            while (current != null)
            {

                if (current.data >= data)
                {
                    var newNode = new DoublyLinkedListNode(data);
                    newNode.next = current;
                    newNode.prev = previous;
                    previous.next = newNode;
                    current.prev = newNode;
                    return head;
                }

                previous = current;
                current = current.next;
            }

            if (previous.data < data)
            {
                var newNode = new DoublyLinkedListNode(data);
                newNode.prev = previous;
                newNode.next = null;
                previous.next = newNode;
            }


            return head;
        }

        //Reverse a doubly linked list
        //https://www.hackerrank.com/challenges/reverse-a-doubly-linked-list/problem
        static DoublyLinkedListNode reverse(DoublyLinkedListNode head)
        {

            if (head == null)
            {
                return null;
            }

            if (head.next == null)
            {
                return head;
            }

            var previous = head;
            var current = previous.next;

            previous.prev = previous.next;
            previous.next = null;

            while (current != null)
            {
                current.prev = current.next;
                current.next = previous;

                previous = current;
                current = current.prev;
            }

            return previous;

        }

        //Find Merge Point of Two Lists
        //https://www.hackerrank.com/challenges/find-the-merge-point-of-two-joined-linked-lists/problem
        static int findMergeNode(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {

            var s1 = new Stack<int>();
            var c1 = head1.next;
            while (c1 != null)
            {
                s1.Push(c1.data);
                c1 = c1.next;
            }

            var s2 = new Stack<int>();
            var c2 = head2.next;
            while (c2 != null)
            {
                s2.Push(c2.data);
                c2 = c2.next;
            }

            int result = s1.Count > s2.Count ? s1.Peek() : s2.Peek();

            while (s1.Count > 0 && s2.Count > 0)
            {
                var d1 = s1.Pop();
                var d2 = s2.Pop();

                if (d1 == d2)
                {
                    result = d1;
                }
                else
                {
                    return result;
                }
            }

            return result;
        }

        //Linked Lists: Detect a Cycle (Not have C#)
        //https://www.hackerrank.com/challenges/ctci-linked-list-cycle/problem
        //bool has_cycle(Node* head)
        //{

        //    if (head == NULL || head->next == NULL)
        //    {
        //        return false;
        //    }

        //    Node* p1 = head;
        //    int counter = 0;

        //    while (p1 != NULL)
        //    {
        //        counter++;
        //        if (counter > 100)
        //        {
        //            return true;
        //        }

        //        p1 = p1->next;
        //    }

        //    return false;
        //}

        class DoublyLinkedListNode
        {
            public int data;
            public DoublyLinkedListNode next;
            public DoublyLinkedListNode prev;

            public DoublyLinkedListNode(int data)
            {
                this.data = data;
            }
        }

        class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int data)
            {
                this.data = data;
            }
        }
    }
}
