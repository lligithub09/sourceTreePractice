using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice.BinaryTree
{
    public class BstTreeNode<T>: IComparable<T>
        where T : IComparable<T>
    {
        public T Data { private set; get; }
        public String Name { private set; get; }
        public BstTreeNode(T data, String name)
        {
            this.Data = data;
            this.Name = name;
        }
        
        public BstTreeNode<T> Right { set; get; }
        public BstTreeNode<T> Left { set; get; }

        /// <summary>
        /// Compares the current node to the provided value
        /// </summary>
        /// <param name="other">The node value to compare to</param>
        /// <returns>1 if the instance value is greater than the provided value, -1 if less or 0 if equal.</returns>
        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }
    }
}
