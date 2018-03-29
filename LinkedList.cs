using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewPractice
{
    class Node
    {
        public long NodeNumber;
        public string NodeName;
        public double NodePrice;

        public Node (long nodeNubmer, string nodeName, double nodePrice)
        {
            this.NodeName = nodeName;
            this.NodeNumber = nodeNubmer;
            this.NodePrice = nodePrice;
        }

        public Node ()
        {
            this.NodeName = "";
            this.NodeNumber = 0;
            this.NodePrice = 0.0;
        }

        public Node Next;
    }

    class LinkedList
    {
        private int size;

        public LinkedList()
        {
            size = 0;
            Head = null;
        }

        public int Count
        {
            get { return size; }
        }

        public Node Head;

        #region stack
        /// <summary>
        /// Stack, last-in-first-out (LIFO)
        /// push is added new item on the top
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Push (Node node)
        {
            return Add(node, true) != 0;
        }

        /// <summary>
        /// Remove the itme from top
        /// </summary>
        /// <returns></returns>
        public Node Pop ()
        {
            if (Head == null)
                return null;
            Node current = Head;
            Head = current.Next;
            size--;
            return current;
        }
        #endregion stack

        /// <summary>
        /// add front
        /// </summary>
        /// <param name="NewItem"></param>
        /// <returns></returns>
        public int Add(Node newNode, bool push)
        {
            Node current = new Node();
            current = newNode;
            if (push)
            {
                current.Next = Head;
                Head = current;
            }
            else
            {
                if (Head == null)
                    Head = current;
                else
                {
                    Node Current = Head;
                    while (Current.Next != null)
                        Current = Current.Next;

                    current.Next = null;
                    Current.Next = current;
                }
            }
            return size++;
        }

        public Node TravesLinked ()
        {
            //before
            //5-> 4-> 3-> 2-> 1-> null 
            //after
            //1-> 2-> 3-> 4-> 5-> null
            //after travers notation:
            //current next -> current previous
            //current -> previous
            //current previous -> current next
            //loop current = current.next
            //edge case: Linked list is null && linked list has only one node

            Node prev =null;
            Node current = Head;
            Node nextNode = null;
            // null linkedlist
            if (Head == null)
                return null;
            //only have one node
            if (current.Next == null)
                return current;
            //has mulitple nodes
            while (current != null)
            {
                nextNode = current.Next;
                current.Next = prev;
                prev = current; 
                current = nextNode;
                //current: 5
                //nextNode: 4
                //current.Next: null
                //pre: 5
                //current: 4

                //nextNode: 3
                //current.Next: 2
                //pre: 4
                //current:3

                //nextNode: 2
                //current.Next: 1
                //pre: 3
                //current:2

                //nextNode: 1
                //current.Next: null
                //pre: 2
                //current:1

                //nextNode: null
                //current.Next: null
                //pre: 1
                //current:null

            }
            Head = prev;
            return Head;
        }

        /// <summary>
        /// Return nth node count from back
        /// 5-> 4-> 3-> 2-> 1-> null 
        /// n = 1, then 4
        /// n = 2, then 3
        /// n = 3, then 2
        /// n = 4, then 1
        /// set two pointers which has n difference, then move 
        /// step to end, which the second pointer will be total count - n;
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Node RetriveNthNodeToEnd(int n)
        {
            Node current = Head;
            Node follower = Head;
            //not negative value
            if (n < 0) return null;
            for (int i=0; i < n; i++)
            {
                if (current == null) return null;
                current = current.Next;
            }

            while(current !=null && current.Next != null)
            {
                current = current.Next;
                follower = follower.Next;
            }

            //current = null, it n value = uplimit, i.e. tail.Next = null;
            return current != null ? follower : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Node RetriveNthNodeToEnd1(int n)
        {
            Node current = Head;
            Node follower = Head;
            int count = 0;
            //not negative value
            if (n < 0) return null;
            while (current.Next != null)
            {
                current = current.Next;
                count++;
                if (count > n)
                {
                    follower = follower.Next;
                }
            }

            //total number of node less than n
            if (count <= n)
            {
                follower = null;
            }

            return follower;
        }

        /// <summary>
        /// Rotate K steps
        /// 1 -> 2 -> 3 -> 4 -> 5 -> null
        /// k = 1;
        /// 5 -> 1 -> 2 -> 3 -> 4 -> null
        /// k = 2;
        /// 4 -> 5 -> 1 -> 2 -> 3 -> null
        /// 1. find node at k by two pointers
        /// 2. set rotated last node.next = null
        /// 3. set the rotated node as head
        /// 4. edge cases: list is null, node count less than k
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public Node RotateListToRightKStep(int k)
        {
            var current = Head;
            Node knode = Head;
            int stepCnt = 0;
            while(current !=null && current.Next != null)
            {
                current = current.Next;
                stepCnt++;
                if (stepCnt > k)
                {
                    knode = knode.Next;
                }
            }

            if (k <= stepCnt)
            {
                current.Next = Head;
                Head = knode.Next;
                knode.Next = null;
            }
            ////rotate go back to original
            //if (k == stepCnt + 1)
            //{
            //    return Head;
            //}
            if (k > stepCnt + 1) 
            {
                Head = null;
            }

            return Head;
        }

        public Node Retrieve(int Position)
        {
            Node Current = Head;

            for (int i = 0; i < Position && Current != null; i++)
                Current = Current.Next;
            return Current;
        }

        /// <summary>
        /// delete head
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            if (Head == null)
            {
                Console.WriteLine("The list is empty");
                return false;
            }

            Node Current;

            Current = Head.Next;
            Head = null;
            Head = Current;
            size--;
            return true;
        }

        /// <summary>
        /// delete position
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        public bool Delete(int Position)
        {
            if (this.Retrieve(Position) == null)
                return false;

            this.Retrieve(Position - 1).Next = this.Retrieve(Position + 1);
            size--;
            return true;
        }

        /// <summary>
        /// delete anyone of node
        /// </summary>
        /// <param name="ItemToDel"></param>
        /// <returns></returns>
        public bool Delete (Node ItemToDel)
        {
            Node Current = new Node();
            if (Head == null)
                return false;
            Current = Head;
            if ((Current.NodeNumber == ItemToDel.NodeNumber) &&
                    (Current.NodeName == ItemToDel.NodeName) &&
                    (Current.NodePrice == ItemToDel.NodePrice))
            {
                Head = Current.Next;
                size--;
                return true;
            }

            for (Current = Head; Current != null; Current=Current.Next )
            {
                if ((Current.NodeNumber == ItemToDel.NodeNumber) &&
                    (Current.NodeName == ItemToDel.NodeName) &&
                    (Current.NodePrice == ItemToDel.NodePrice))
                {
                    Current = Current.Next;
                    size--;
                    return true;
                }                 
            }
            return false;
        }

        public Node Find(Node ItemToFind)
        {
            Node Current = new Node();

            if (ItemToFind == null)
                return null;

            for (Current = Head; Current != null; Current = Current.Next)
            {
                if ((Current.NodeNumber == ItemToFind.NodeNumber) &&
                    (Current.NodeName == ItemToFind.NodeName) &&
                    (Current.NodePrice == ItemToFind.NodePrice))
                    return Current;
            }
            return null;
        }

        /// <summary>
        /// using a buffer in hashset remove any dups values
        /// </summary>
        public void DeleteDups (LinkedList list)
        {
            HashSet<double> set = new HashSet<double>();
            Node current = list.Head;
            while (current !=null)
            {
                if (set.Contains(current.NodePrice)) list.Delete(current);
                else
                {
                    set.Add(current.NodePrice);
                    //current = current.Next;
                }
                current = current.Next;
            }
        }
    }

}
