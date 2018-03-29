using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice.BinaryTree
{
    public class BstTree<T> : IComparable<T>
        where T: IComparable<T>
    {
        private BstTreeNode<T> _root;
        private int _count;

        public int Count
        {
            get { return _count; }
        }

        public int MaxLeftDepth
        {
            get {
                return TreeOneSideMaxDepth(_root, true);
            }
        }

        public int MaxRightDepth
        {
            get {
                return TreeOneSideMaxDepth(_root, false);
            }
        }

        public int MaxDepth
        {
            get { return TreeNodeDepth(_root); }
        }

        public void Add(BstTreeNode<T> node)
        {
            if (_root == null)
            {
                _root = node;
            }
            else
            {
                AddTo(_root, node);
            }
            _count++;
        }

        /// <summary>
        /// Add to suitable position
        /// </summary>
        /// <param name="root"></param>
        /// <param name="node"></param>
        private void AddTo(BstTreeNode<T> root, BstTreeNode<T> node)
        {
            if (root == null) root = node;
            BstTreeNode<T> current = root;
            if (current.CompareTo(node.Data) > 0)
            {
                if (current.Left == null)
                {
                    current.Left = node;
                }
                else
                {
                    AddTo(current.Left, node);
                }
            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = node;
                }
                else
                {
                    AddTo(current.Right, node);
                }
            }
        }

        /// <summary>
        /// Calculate any node depth
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int TreeNodeDepth(BstTreeNode<T> node)
        {
            if (node == null) return 0;
            return Math.Max(TreeNodeDepth(node.Left), TreeNodeDepth(node.Right)) + 1;       
        }

        /// <summary>
        /// Queue total number node for each level, then dequeue those itme and add all its child node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int TreeNodeDepthQueue(BstTreeNode<T> node)
        {
            int depth = 0;
            var queue = new Queue<BstTreeNode<T>>();
            if (node != null) queue.Enqueue(node);
            while (queue.Any())
            {
                var size = queue.Count;
                depth++; //count the level
                for (int i = 0; i < size; i++) //dequeue the previous level
                {
                    var top = queue.Dequeue();

                    if (top.Left != null)
                    {
                        queue.Enqueue(top.Left);
                    }

                    if (top.Right != null)
                    {
                        queue.Enqueue(top.Right);
                    }
                }
            }

            return depth;
        }

        /// <summary>
        /// Breadth First Traversal, node level search
        /// if nodeLevel less than zero, then output all nodes in order of level
        /// otherwise, output nodes in level at nodeLevel
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public string BreadthFirstTraversalWithQueue(BstTreeNode<T> node, int nodeLevel)
        {
            StringBuilder results = new StringBuilder();
            int level = 0;
            var queue = new Queue<BstTreeNode<T>>();
            if (node == null)
            {
                results.Append("Root node is null");
            }
            else
            {
                //define level, the root level 1
                queue.Enqueue(node);
                while (queue.Any())
                {
                    //get size of previous level
                    var size = queue.Count;
                    //incrase level
                    level++;
                    if (nodeLevel < 0)
                        results.Append(string.Format("Level: {0} - ", level));
                    else
                    {
                        if (nodeLevel == level)
                            results.Append(string.Format("Level: {0} - ", level));
                    }
                    for(int i=0; i<size; i++)
                    {
                        var dqNode= queue.Dequeue();
                        if (nodeLevel < 0)
                            results.Append(string.Format("name {0}, value {1}; ", dqNode.Name, dqNode.Data));
                        else
                        {
                            if (nodeLevel == level)
                                results.Append(string.Format("name {0}, value {1}; ", dqNode.Name, dqNode.Data));
                        }
                        if(dqNode.Left != null)
                        {
                            queue.Enqueue(dqNode.Left);
                        }
                        if(dqNode.Right != null)
                        {
                            queue.Enqueue(dqNode.Right);
                        }
                    }
                }
            }
            return results.ToString();
        }

        /// <summary>
        /// Return minum depth of bst
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int TreeMinumNodeDepth(BstTreeNode<T> node)
        {
            if (node == null) return 0;
            return Math.Min(TreeMinumNodeDepth(node.Left), TreeMinumNodeDepth(node.Right)) + 1;
            //int result = 0;
            //if (node != null)
            //{
            //    if (node.Left != null && node.Right != null)
            //    {
            //        result = Math.Min(TreeMinumNodeDepth(node.Left), TreeMinumNodeDepth(node.Right)) + 1;
            //    }
            //    else if (node.Left != null)
            //    {
            //        result = TreeMinumNodeDepth(node.Right) + 1;
            //    }
            //    else
            //    {
            //        result = TreeMinumNodeDepth(node.Left) + 1;
            //    }
            //}
            //return result;
        }

        /// <summary>
        /// Calculate min depth with Queue
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int TreeMinumNodeDepthQueue(BstTreeNode<T> node)
        {
            var height = 0;
            var queue = new Queue<BstTreeNode<T>>();
            if (node != null) queue.Enqueue(node);

            while (queue.Any())
            {
                height++;
                var size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    var top = queue.Dequeue();
                    //one of the leaf node found
                    //if (top.Left == null && top.Right == null) return height;
                    if (top.Left == null || top.Right == null)
                    {
                        //break;
                        return height;
                    }
                    else
                    {
                        queue.Enqueue(top.Left);
                        queue.Enqueue(top.Right);
                    }
                }
            }     
            return height;
        }

        /// <summary>
        /// Return one side max length of BST
        /// </summary>
        /// <param name="node"></param>
        /// <param name="isLeft"></param>
        /// <returns></returns>
        public int TreeOneSideMaxDepth(BstTreeNode<T> node, bool isLeft)
        {
            //may need to compare the value with root.
            //if less than root, go left otherwise go right
            int result = 0;
            BstTreeNode<T> current;
            if (node != null)
            {
                current = isLeft ? node.Left : node.Right;
                result = TreeNodeDepth(current);
            }
            return result + 1;
        }

        /// <summary>
        /// flatten tree node in in-order
        /// </summary>
        /// <param name="node"></param>
        /// <param name="list"></param>
        public void FlattenInOrder(BstTreeNode<T> node, ref StringBuilder flattenList)
        {
            //var output = new StringBuilder();
            if (node != null)
            {
                FlattenInOrder(node.Left, ref flattenList);
                flattenList.Append(node.Data);
                flattenList.Append(" (" + node.Name +")");
                flattenList.Append("-> ");
                FlattenInOrder(node.Right, ref flattenList);
            }
        }

        /// <summary>
        /// ??
        /// </summary>
        /// <param name="node"></param>
        public BstTreeNode<T> FlattenInOrderStack(BstTreeNode<T> node)
        {
            BstTreeNode<T> newRoot = null;
            var myStack = new Stack<BstTreeNode<T>>();

            if (node != null)
                myStack.Push(node);

            while (myStack.Count > 0)
            {
                var top = myStack.Pop();

                if (top.Right != null)
                {
                    myStack.Push(top.Right);
                    top.Right = null;
                }

                if (top.Left != null)
                {
                    myStack.Push(top.Left);
                    top.Left = null;
                }

                if (newRoot == null)
                {
                    newRoot = top;
                }
                else
                {
                    newRoot.Right = top;
                    newRoot = top;
                }
            }
             return newRoot;
            
        }

        public LinkedList<int> InOrderWithStack(BstTreeNode<T> root)
        {
            var stack = new Stack<BstTreeNode<T>>();
            LinkedList<int> llist = new LinkedList<int>();
            var current = root;
            while (stack.Count> 0 || current != null)
            {
                if (current != null) {
                    stack.Push(current);                 
                    current = current.Left;
                }
               else
                {
                    current = stack.Pop();
                    int value = Convert.ToInt32(current.Data);
                    if (llist.Count == 0)
                    {
                        llist.AddFirst(value);
                    }
                    else
                    {
                        llist.AddLast(value);
                    }
                    current = current.Right;             
                }
            }
            return llist;
        }

        /// <summary>
        /// flatten tree node in preorder-order
        /// </summary>
        /// <param name="node"></param>
        /// <param name="list"></param>
        public void FlattenPreOrder(BstTreeNode<T> node, ref StringBuilder flattenList)
        {
            //var output = new StringBuilder();
            if (node != null)
            {
                flattenList.Append(node.Data);
                flattenList.Append(" (" + node.Name + ")");
                flattenList.Append("-> ");
                FlattenPreOrder(node.Left, ref flattenList);
                FlattenPreOrder(node.Right, ref flattenList);
            }
        }

        public string FlattenPreOrderStack(BstTreeNode<T> root)
        {
            var stack = new Stack<BstTreeNode<T>>();
            StringBuilder flattenList = new StringBuilder();
            var current = root;
            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    flattenList.Append(current.Data);
                    flattenList.Append(" (" + current.Name + ")");
                    flattenList.Append("-> ");
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    current = stack.Pop();
                    current = current.Right;
                }
            }
            return flattenList.ToString();
        }


        /// <summary>
        /// flatten tree node in post-order
        /// </summary>
        /// <param name="node"></param>
        /// <param name="list"></param>
        public void FlattenPostOrder(BstTreeNode<T> node, ref StringBuilder flattenList)
        {
            //var output = new StringBuilder();
            if (node != null)
            {
                FlattenPostOrder(node.Left, ref flattenList);
                FlattenPostOrder(node.Right, ref flattenList);
                flattenList.Append(node.Data);
                flattenList.Append(" (" + node.Name + ")");
                flattenList.Append("-> ");
            }
        }

        public string FlattenPostOrderStack(BstTreeNode<T> root)
        {
            var stack = new Stack<BstTreeNode<T>>();
            StringBuilder flattenList = new StringBuilder();
            var current = root;
            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    BstTreeNode<T> temp = stack.Peek().Right;
                    if (temp == null)
                    {
                        temp = stack.Pop();
                        flattenList.Append(temp.Data);
                        flattenList.Append(" (" + temp.Name + ")");
                        flattenList.Append("-> ");

                        while (!stack.Any() && temp == stack.Peek().Right)
                        {
                            temp = stack.Pop();
                            flattenList.Append(temp.Data);
                            flattenList.Append(" (" + temp.Name + ")");
                            flattenList.Append("-> ");
                        }
                    }
                    else
                    {
                        current = temp;
                    }
                }
            }
            return flattenList.ToString();
        }

        // Simple 'drawing' routines
        private string drawNode(BstTreeNode<T> node)
        {
            if (node == null)
                return "empty";

            if ((node.Left == null) && (node.Right == null))
                return node.Data +"[" + node.Name +"]";
            if ((node.Left != null) && (node.Right == null))
                return node.Data + "[" + node.Name + "]" + "(" + drawNode(node.Left) + ", _null)";

            if ((node.Right != null) && (node.Left == null))
                return node.Data + "[" + node.Name + "]" + "(_null, " + drawNode(node.Right) + ")";

            return node.Data + "[" + node.Name + "]" + "(" + drawNode(node.Left) + ", " + drawNode(node.Right) + ")";
        }


        /// <summary>
        /// Return the tree depicted as a simple string, useful for debugging, eg
        /// 50(40(30(20, 35), 45(44, 46)), 60)
        /// </summary>
        /// <returns>Returns the tree</returns>
        public string DrawTree(BstTreeNode<T> node)
        {
            return drawNode(node);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(T other)
        {
            throw new NotImplementedException();
        }
    }
}
