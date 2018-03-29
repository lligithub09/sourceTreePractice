using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterviewPractice.BinaryTree;
using InterviewPractice.Dynamic;
using InterviewPractice.Pointers;
using InterviewPractice.Stack;

namespace InterviewPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //interviews:
            //--clearifications
            //--think out loud
            //--talk before you write
            //--think edge case
            //--test your solution

            DataStr();
            //LinkedListMethods();
            //ArrayString();
            //TwoSum();
            //AddTwoLinkedListed();
            //CheckPrString();
            //Console.WriteLine(CheckAnagram("abcd", "cbaa"));
            //Console.WriteLine((new LeetCode()).HammingDistince(10, 2));
            //Console.ReadLine();

            //binary tree
            //Bst();

            //dynamic program
            //Dps();

            ////points
            //Pointers();

            //Stack
            //StackAndQueue();


        }

        #region Linked list method
        static void LinkedListMethods()
        {
            LinkedList Parts = new LinkedList();
            Node Part;
            Node PartToFind;

            //add to end
            Part = new Node();
            Part.NodeNumber = 1;
            Part.NodeName = "Air Filter";
            Part.NodePrice = 8.75;
            Parts.Push(Part);

            Part = new Node();
            Part.NodeNumber = 2;
            Part.NodeName = "Clutch Disk";
            Part.NodePrice = 47.15;
            Parts.Push(Part);

            Part = new Node();
            Part.NodeNumber = 3;
            Part.NodeName = "Brake Disk";
            Part.NodePrice = 35.15;
            Parts.Push(Part);

            //duplicate
            Part = new Node();
            Part.NodeNumber = 2;
            Part.NodeName = "Clutch Disk";
            Part.NodePrice = 47.15;
            Parts.Push(Part);

            Part = new Node();
            Part.NodeNumber = 4;
            Part.NodeName = "A/C Filter Drier";
            Part.NodePrice = 55.55;
            Parts.Push(Part);

            //add to end
            //Part = new Node();
            //Part.NodeNumber = 1;
            //Part.NodeName = "Air Filter";
            //Part.NodePrice = 8.75;
            //Parts.Add(Part, false);

            //Part = new Node();
            //Part.NodeNumber = 2;
            //Part.NodeName = "Clutch Disk";
            //Part.NodePrice = 47.15;
            //Parts.Add(Part, false);

            //Part = new Node();
            //Part.NodeNumber = 3;
            //Part.NodeName = "Brake Disk";
            //Part.NodePrice = 35.15;
            //Parts.Add(Part, false);

            //Part = new Node();
            //Part.NodeNumber = 4;
            //Part.NodeName = "A/C Filter Drier";
            //Part.NodePrice = 55.55;
            //Parts.Add(Part, false);

            Console.WriteLine(" -=- Store Inventory -=-");
            Console.WriteLine("Number of Parts: {0}", Parts.Count);

            //var node = Parts.Retrieve(0);
            //Console.WriteLine("Retrieve position {0}: node number {1}", 0, node.NodeNumber);


            for (int i = 0; i < Parts.Count; i++)
            {
                Node part = Parts.Retrieve(i);
                Console.WriteLine("\nCar Part Information");
                Console.WriteLine("Part #:      {0}", part.NodeNumber);
                Console.WriteLine("Description: {0}", part.NodeName);
                Console.WriteLine("Unit Price:  {0:C}", part.NodePrice);
            }


            //delete duplicated node;
            Parts.DeleteDups(Parts);


            //Parts.TravesLinked();
            var popNode = Parts.Pop();
            Console.WriteLine("1st Pop node number {0}", popNode.NodeNumber);

            for (int i = 0; i < Parts.Count; i++)
            {
                Node part = Parts.Retrieve(i);
                Console.WriteLine("\nCar Part Information");
                Console.WriteLine("Part #:      {0}", part.NodeNumber);
                Console.WriteLine("Description: {0}", part.NodeName);
                Console.WriteLine("Unit Price:  {0:C}", part.NodePrice);
            }

            popNode = Parts.Pop();
            Console.WriteLine("2nd Pop node number {0}", popNode.NodeNumber);

            for (int i = 0; i < Parts.Count; i++)
            {
                Node part = Parts.Retrieve(i);
                Console.WriteLine("\nCar Part Information");
                Console.WriteLine("Part #:      {0}", part.NodeNumber);
                Console.WriteLine("Description: {0}", part.NodeName);
                Console.WriteLine("Unit Price:  {0:C}", part.NodePrice);
            }

            //Delete head
            Parts.Delete();

            //Delete at a position
            Parts.Delete(2);

            for (int i = 0; i < Parts.Count; i++)
            {
                Node part = Parts.Retrieve(i);
                Console.WriteLine("\nCar Part Information");
                Console.WriteLine("Part #:      {0}", part.NodeNumber);
                Console.WriteLine("Description: {0}", part.NodeName);
                Console.WriteLine("Unit Price:  {0:C}", part.NodePrice);
            }

            //find a node
            PartToFind = new Node();
            PartToFind.NodeNumber = 3;
            PartToFind.NodeName = "Brake Disk";
            PartToFind.NodePrice = 35.15;

            Node found = Parts.Find(PartToFind);
            if (found != null)
                Console.WriteLine(string.Format("Item was found withe Part #{0}", found.NodeNumber));
            else
                Console.WriteLine("\nItem not found\n");

            Part = new Node();
            Part.NodeNumber = 3;
            Part.NodeName = "Brake Disk";
            Part.NodePrice = 35.15;
            Parts.Delete(Part);
            for (int i = 0; i < Parts.Count; i++)
            {
                Node part = Parts.Retrieve(i);
                Console.WriteLine("\nCar Part Information");
                Console.WriteLine("Part #:      {0}", part.NodeNumber);
                Console.WriteLine("Description: {0}", part.NodeName);
                Console.WriteLine("Unit Price:  {0:C}", part.NodePrice);
            }

            Console.WriteLine(" -=- Store Inventory -=-");
            Console.WriteLine("Number of Parts: {0}", Parts.Count);
        }
        #endregion

        #region ArrayString
        static void ArrayString()
        {
            //ArrayAndString.IsUninquerchars("this is a testing");
            //Console.WriteLine(ArrayAndString.ReversebyArrary("This a TEST "));
            //Console.WriteLine(ArrayAndString.ReversebySb("this is a tesT "));
            //Console.WriteLine(ArrayAndString.ReverseXor("THIS a test "));
            //Console.WriteLine(ArrayAndString.ReversebyArrary("\U00010380\U00010381"));
            //Console.WriteLine(ArrayAndString.ReverseUnicod("\U00010380\U00010381"));

            int iterations = 10000;
            string text = "This is test";

            //delegate for reverse
            //ArrayAndString.Benchmark(String.Format("String Builder (Length: {0})", text.Length), ArrayAndString.ReversebySb, iterations, text);
            //ArrayAndString.Benchmark(String.Format("Array.Reverse (Length: {0})", text.Length), ArrayAndString.ReversebyArrary, iterations, text);
            //ArrayAndString.Benchmark(String.Format("Xor (Length: {0})", text.Length), ArrayAndString.ReverseXor, iterations, text);

            //Console.WriteLine(ArrayAndString.RemoveDuplicateCharsNormal("ABCD DE HA"));
            //Console.WriteLine(ArrayAndString.RemoveDuplicateCharsArray("ABCD DE HA"));
            ////performance
            //ArrayAndString.Benchmark(String.Format("String normal cat (Length: {0})", text.Length), ArrayAndString.RemoveDuplicateCharsNormal, iterations, text);
            //ArrayAndString.Benchmark(String.Format("Array method (Length: {0})", text.Length), ArrayAndString.RemoveDuplicateCharsArray, iterations, text);

            //Console.WriteLine(ArrayAndString.CheckAnagramByArraySort(text, text));
            //Console.WriteLine(ArrayAndString.CheckAnagramByArraySort("ABCDE", "BBCDE"));
            //Console.WriteLine(ArrayAndString.CheckAnagramByArraySort("ABCDE", "aBCDE"));
            //Console.WriteLine(ArrayAndString.CheckAnagramByCharCnt("BCDEA", "BACDE"));
            //Console.WriteLine(ArrayAndString.CheckAnagramByCharCnt(text, text));
            //Console.WriteLine(ArrayAndString.CheckAnagramByCharCnt("BBCDE", "ABCDE"));
            //Console.WriteLine(ArrayAndString.CheckAnagramByCharCnt("ABCDE", "aBCDE"));
            //performance
            //ArrayAndString.Benchmark(String.Format("String Anagrams by sort (Length: {0})", text.Length),
            //                         ArrayAndString.CheckAnagramByArraySort, iterations, text, text);
            //ArrayAndString.Benchmark(String.Format("String Anagrams by count (Length: {0})", text.Length),
            //                         ArrayAndString.CheckAnagramByCharCnt, iterations, text, text);

            //perfomarnce

            //int[,] matrix = new int[,]
            //                      {
            //                          {1, 2, 3, 4},
            //                          {2, 0, 4, 5},
            //                          {3, 4, 5, 6}
            //                      };
            //ArrayAndString.SetZeros(ref matrix);
            Console.WriteLine(ArrayAndString.CheckWordRotation("apple", "pleap"));
            Console.WriteLine(ArrayAndString.CheckWordRotation("apple", "plaep"));
        }

        #endregion

        #region Data structure
        static void DataStr()
        {
            DataStructure d = new DataStructure();
            d.DupDictionary();
            d.DupHashTable();
            d.DupHashSet();
        }

        static void TwoSum()
        {
            int[] nums = new int[4] { 2, 7, 11, 15 };

            var leetroot = new LeetCode();

            //var retVal = leetroot.TwoSumByHash(nums, 22);
            var retval = leetroot.TwoSumByDictionary(nums, 22);

        }

        //static void AddTwoLinkedListed()
        //{
        //    var l1 = new LinkedListNode<int>(1);
        //    l1.Next =l1;
        //    l1.Next.Next.Value = 3;

        //    var l2 = new LinkedListNode<int>(3);
        //    l2.Next.Value = 7;
        //    l2.Next.Next.Value = 4;

        //    var leetroot = new LeetCode();

        //    var result = leetroot.AddTwoNumbers(l1, l2);

        //}
        #endregion

        #region string
        static void CheckPrString()
        {
            var stringList = new List<string>() { "abcde", "e", "001qw3", "abcdedcba", "abcddcba" };
            var leetcode = new LeetCode();
            foreach (var str in stringList)
            {
                Console.WriteLine("Loop method: " + leetcode.IsPrStrByLooping(str));
                Console.WriteLine("Receisive method: " + leetcode.IsPrByRecr(str));
            }
        }

        static bool CheckAnagram(string s1, string s2)
        {
            var leetCode = new LeetCode();
            return leetCode.IsAnagram(s1, s2);
        }
        #endregion end sring

        #region BST
        static void Bst()
        {
            BstTreeNode<int> node = new BstTreeNode<int>(4, "root");
            BstTreeNode<int> node1L = new BstTreeNode<int>(2, "1L");
            BstTreeNode<int> node2LL = new BstTreeNode<int>(1, "2LL");
            BstTreeNode<int> node2LR = new BstTreeNode<int>(3, "2LR");
            BstTreeNode<int> node1R = new BstTreeNode<int>(6, "1R");
            BstTreeNode<int> node2RR = new BstTreeNode<int>(8, "2RR");
            BstTreeNode<int> node3RR = new BstTreeNode<int>(10, "3RR");

            BstTree<int> bstTree = new BstTree<int>();
            Console.WriteLine("Max Depth null root: " + bstTree.MaxDepth);
            bstTree.Add(node);
            Console.WriteLine("Max Depth root: " + bstTree.MaxDepth);
            Console.WriteLine("Min Depth root: " + bstTree.TreeMinumNodeDepth(node));
            bstTree.Add(node1L);
            Console.WriteLine("Max Depth root -> 1L: " + bstTree.MaxDepth);
            bstTree.Add(node1R);
            bstTree.Add(node2LL);
            bstTree.Add(node2RR);
            bstTree.Add(node3RR);
            Console.WriteLine("Max Depth root -> 2L: " + bstTree.MaxDepth);
            bstTree.Add(node2LR);
            Console.WriteLine("Max Depth root -> 2LR: " + bstTree.MaxDepth);
            Console.WriteLine("***********BstTree*********");
            Console.WriteLine(bstTree.DrawTree(node));
            Console.WriteLine("***********Queue*********");
            Console.WriteLine("Max Depth (queue) root -> 2LR: " + bstTree.TreeNodeDepthQueue(node));
            Console.WriteLine("Max Depth (queue) 1R -> 1R: " + bstTree.TreeNodeDepthQueue(node1R));
            Console.WriteLine("Max Depth (queue) 1L -> 2LR: " + bstTree.TreeNodeDepthQueue(node1L));
            Console.WriteLine("Min Depth (queue) root -> 2LR: " + bstTree.TreeMinumNodeDepthQueue(node));
            Console.WriteLine("Min Depth (queue) 1R -> 1R: " + bstTree.TreeMinumNodeDepthQueue(node1R));
            Console.WriteLine("Min Depth (queue) 1L -> 2LR: " + bstTree.TreeMinumNodeDepthQueue(node1L));
            Console.WriteLine("***********Queue*********");
            Console.WriteLine("Max Depth node1L -> 2LL: " + bstTree.TreeNodeDepth(node1L));
            Console.WriteLine("Min Depth cursive: " + bstTree.TreeMinumNodeDepth(node));
            Console.WriteLine("Min Depth queue: " + bstTree.TreeMinumNodeDepthQueue(node));
            Console.WriteLine("Max L Depth root -> 2LR: " + bstTree.MaxLeftDepth);
            Console.WriteLine("Max R Depth root -> 1R: " + bstTree.MaxRightDepth);
            Console.WriteLine("Max L Depth node1L -> 2LL: " + bstTree.TreeOneSideMaxDepth(node1L, true));
            Console.WriteLine("Max R Depth node1R -> 1R: " + bstTree.TreeOneSideMaxDepth(node1R, false));
            Console.WriteLine("***********Flatten*********");
            StringBuilder flattenList = new StringBuilder();
            bstTree.FlattenInOrder(node, ref flattenList);
            Console.WriteLine("In-Order: " + flattenList.ToString());
            Console.WriteLine("***********Inorder Stack, return linkedList*********");
            var linkedList = bstTree.InOrderWithStack(node);
            foreach (var lnode in linkedList)
            {
                Console.Write(lnode.ToString() + "-> ");
            }
            Console.WriteLine();
            Console.WriteLine("***********Inorder Stack*********");
            //Console.WriteLine("In-Order (stack): " + 
            flattenList = new StringBuilder();
            //var flatterNode = bstTree.FlattenInOrderStack(node);
            bstTree.FlattenPreOrder(node, ref flattenList);
            Console.WriteLine("Pre-Order: " + flattenList.ToString());
            Console.WriteLine("PreOrder Stack: " + bstTree.FlattenPreOrderStack(node));
            flattenList = new StringBuilder();
            bstTree.FlattenPostOrder(node, ref flattenList);
            Console.WriteLine("PostOrder: " + flattenList.ToString());
            Console.WriteLine("PostOrder Stack: " + bstTree.FlattenPostOrderStack(node));
            Console.WriteLine("***********Flatten*********");
            Console.WriteLine("***********Breadth First Traversal*********");
            Console.WriteLine(bstTree.BreadthFirstTraversalWithQueue(node, -1));
            Console.WriteLine(bstTree.BreadthFirstTraversalWithQueue(node, 2));
            Console.WriteLine("***********Breadth First Traversal*********");
            Console.WriteLine("Total Count: " + bstTree.Count);

            /*            Max Depth null root: 0
            Max Depth root: 1
            Min Depth root: 1
            Max Depth root-> 1L: 2
            Max Depth root-> 2L: 4
            Max Depth root-> 2LR: 4
            * **********BstTree * ********
            4[root](2[1L](1[2LL], 3[2LR]), 6[1R](_null, 8[2RR](_null, 10[3RR])))
            * **********Queue * ********
            Max Depth(queue) root-> 2LR: 4
            Max Depth (queue)1R-> 1R: 3
            Max Depth(queue) 1L-> 2LR: 2
            Min Depth(queue) root-> 2LR: 3
            Min Depth(queue) 1R-> 1R: 1
            Min Depth(queue) 1L-> 2LR: 2
            * **********Queue * ********
            Max Depth node1L-> 2LL: 2
            Min Depth-> 2LL: 2
            Max L Depth root-> 2LR: 3
            Max R Depth root-> 1R: 4
            Max L Depth node1L-> 2LL: 2
            Max R Depth node1R-> 1R: 3
            * **********Flatten * ********
            In-Order: 1 (2LL)-> 2 (1L)-> 3 (2LR)-> 4 (root)-> 6 (1R)-> 8 (2RR)-> 10 (3RR)->

            ***********Inorder Stack, return linkedList*********
            1-> 2-> 3-> 4-> 6-> 8-> 10->
            ***********Inorder Stack*********
            Pre-Order: 4 (root)-> 2 (1L)-> 1 (2LL)-> 3 (2LR)-> 6 (1R)-> 8 (2RR)-> 10 (3RR)->

            PreOrder Stack: 4 (root)-> 2 (1L)-> 1 (2LL)-> 3 (2LR)-> 6 (1R)-> 8 (2RR)-> 10 (3RR)->
            PostOrder: 1 (2LL)-> 3 (2LR)-> 2 (1L)-> 10 (3RR)-> 8 (2RR)-> 6 (1R)-> 4 (root)->
       
           **********Flatten * ********
            Total Count: 7*/
        }
        #endregion BST

        #region dynamic programming
        static void Dps()
        {
            //dynamic
            var dynamic = new DynamicProgram();
            //Fib(dynamic);
            //int[] input = new int[] { 10, 9, 2, 5, 3, 7, 101, 18, 20, 29, 60, 11 };
            ////max length 7 either [2, 5, 7, 18, 20, 29, 60]  or [2, 3, 7, 18, 20, 29, 60]
            ////{ 10, 9, 2, 5, 3, 7, 101, 18 }; //max length 4
            int[] input = new int[] { 10, 9, 2, 5, 3, 7, 101, 18, 1};
            Console.WriteLine("longest increase number: " + dynamic.LengthOfLIS(input));
            //Console.WriteLine("longest increase number (binary search): " + dynamic.LengthOfLISBinarySearch(input));
            //longest common substring
            //"cgefaaaaaabvbbbbbbp", "hqwaaafavbpbbbbbbb" -> 6 bbbbbb
            //"cgefaaaaaabvp", "hqwaaafavbpb" -> 3 aaa
            //Console.WriteLine("Longest common subsrting: " + dynamic.LCSubstring("cbad", "efhbac")); 
            //longest common sequence
            //Console.WriteLine("Longest common sequence: " + dynamic.LCSubsequence("abcdaf", "abcf"));

        }

        static void Fib(DynamicProgram dynamic)
        {
            //1, 1, 2, 3, 5, 8, 13, 21
            int totalcall = 0;
            Console.WriteLine("recur n=5: " + dynamic.FibonacciRecur(5, ref totalcall)); //5 
            Console.WriteLine("Recursion Total calls: " + totalcall);
            totalcall = 0;
            Console.WriteLine("dynamic n=5: " + dynamic.FibonacciDynamic(5, ref totalcall));
            Console.WriteLine("Dynamic Total calls: " + totalcall);
            totalcall = 0;
            Console.WriteLine("dynamic bottomToUp n=5: " + dynamic.FibnoaccBottomToUp(5, ref totalcall));
            Console.WriteLine("Dynamic bottomToUp Total calls: " + totalcall);
            totalcall = 0;
            Console.WriteLine("recur n=6: " + dynamic.FibonacciRecur(20, ref totalcall)); //6765
            Console.WriteLine("Recursion Total calls: " + totalcall);
            totalcall = 0;
            Console.WriteLine("dynamic n=8: " + dynamic.FibonacciDynamic(20, ref totalcall));
            Console.WriteLine("Dynamic Total calls: " + totalcall);
            totalcall = 0;
            Console.WriteLine("dynamic bottomToUp n=20: " + dynamic.FibnoaccBottomToUp(20, ref totalcall));
            Console.WriteLine("Dynamic bottomToUp Total calls: " + totalcall);
            /*
             recur n=5: 5
            Recursion Total calls: 9
            dynamic n=5: 5
            Dynamic Total calls: 5
            recur n=6: 6765
            dynamic bottomToUp n=5: 5
            Dynamic bottomToUp Total calls: 1
            Recursion Total calls: 13529
            dynamic n=8: 6765
            Dynamic Total calls: 20
            dynamic bottomToUp n=5: 5
            Dynamic bottomToUp Total calls: 1
            */
        }
        #endregion

        #region pointers
        static void Pointers()
        {

            //int[] sortedArr = new int[] {1, 5, 3, 8, 2, 6, 7, 4 };
            //var pointer = new Pointer() { };
            //Console.WriteLine(pointer.FindSubArraySum(sortedArr, 8, true));
            //Console.WriteLine(pointer.FindSubArraySum(sortedArr, 8, false));

            LinkedList Parts = new LinkedList();
            Node Part;
            Node PartToFind;

            //add to end
            Part = new Node();
            Part.NodeNumber = 5;
            Part.NodeName = "Dishboard";
            Part.NodePrice = 46.15;
            Parts.Push(Part);

            Part = new Node();
            Part.NodeNumber = 4;
            Part.NodeName = "Air Filter";
            Part.NodePrice = 8.75;
            Parts.Push(Part);

            Part = new Node();
            Part.NodeNumber = 3;
            Part.NodeName = "Clutch Disk";
            Part.NodePrice = 47.15;
            Parts.Push(Part);

            Part = new Node();
            Part.NodeNumber = 2;
            Part.NodeName = "Brake Disk";
            Part.NodePrice = 35.15;
            Parts.Push(Part);

            Part = new Node();
            Part.NodeNumber = 1;
            Part.NodeName = "A/C Filter Drier";
            Part.NodePrice = 55.55;
            Parts.Push(Part);

            //var node = Parts.TravesLinked();
            //var node = Parts.RetriveNthNodeToEnd(0);
            //var node1 = Parts.RetriveNthNodeToEnd1(0);
            var node = Parts.RotateListToRightKStep(6);

        }


        #endregion

        #region stack
        static void StackAndQueue()
        {
            var stack = new StackAndQueue();
            //Console.WriteLine(stack.LargestRectInHist(new int[] {3, 2, 4, 3}));
            Console.WriteLine(stack.MaxTrapWater(new int[] { 3, 0, 2, 0, 1}));
            Console.WriteLine(stack.MaxTrapWaterStack(new int[] { 3, 0, 2, 0, 1 }));
            //Console.WriteLine(stack.ValidPareenthese("({[]()}"));
        }
        #endregion
    }
}
