using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice.Stack
{
    public class StackAndQueue
    {
        /// <summary>
        /// We have discussed a Divide and Conquer based O(nLogn) solution 
        /// for this problem. In this post, O(n) time solution 
        /// is discussed. Like the previous post, width of all bars is assumed 
        /// to be 1 for simplicity. For every bar ‘x’, 
        /// we calculate the area with ‘x’ as the smallest bar in the rectangle. 
        /// If we calculate such area for every bar ‘x’ and 
        /// find the maximum of all areas, our task is done. How to calculate 
        /// area with ‘x’ as smallest bar? We need to 
        /// know index of the first smaller (smaller than ‘x’) bar on left 
        /// of ‘x’ and index of first smaller bar on right of ‘x’. 
        /// Let us call these indexes as ‘left index’ and ‘right index’ 
        /// respectively. We traverse all bars from left to right, maintain 
        /// a stack of bars. Every bar is pushed to stack once. A bar is 
        /// popped from stack when a bar of smaller height is seen.When a bar 
        /// is popped, we calculate the area with the 
        /// popped bar as smallest bar. How do we get left and right indexes 
        /// of the popped bar – the current index tells 
        /// us the ‘right index’ and index of previous item in stack is the 
        /// ‘left index’. 
        /// Following is the complete algorithm.
        /// 1) Create an empty stack.
        /// 2) Start from first bar, and do following for every bar ‘hist[i]’ 
        /// where ‘i’ varies from 0 to n-1.
        /// ……a) If stack is empty or hist[i] is higher than the bar at top 
        /// of stack, then push ‘i’ to stack.
        /// ……b) If this bar is smaller than the top of stack, then keep removing
        /// the top of stack while top of the stack is greater.
        /// Let the removed bar be hist[tp]. Calculate area of rectangle 
        /// with hist[tp] as smallest bar. For hist[tp], 
        /// the ‘left index’ is previous (previous to tp) item in stack and 
        /// ‘right index’ is ‘i’ (current index).
        /// 3) If the stack is not empty, then one by one remove all bars 
        /// from stack and do step 2.b for every removed bar.
        /// Following is implementation of the above algorithm.
        /// </summary>
        /// <param name="histogram"></param>
        /// <returns></returns>
        public int LargestRectInHist(int[] histogram)
        {
            int maxArea = 0;
            Stack<int> s = new Stack<int>();

            int cnt = histogram.Length;
            int rightIndex = 0; //right index, which will point to the highest 
            int leftIndex = 0;
            int areaTop = 0;
            while (rightIndex < cnt)
            {
                if (!s.Any() || histogram[s.Peek()] < histogram[rightIndex] )
                {
                    s.Push(rightIndex++);  //equal: s.Push(rightIndex); rightIndex++
                }
                else
                {
                    leftIndex = s.Peek(); //start from rightIndex - 1
                    s.Pop(); //after pop(), the top index in stack less than leftIndex
                    areaTop = histogram[leftIndex] * (!s.Any() ? rightIndex : rightIndex - s.Peek() - 1);
                    maxArea = Math.Max(maxArea, areaTop);
                }
            }

            while (s.Any())
            {
                leftIndex = s.Peek();
                s.Pop();
                areaTop = histogram[leftIndex] * (!s.Any() ? rightIndex : rightIndex - s.Peek() - 1);
                maxArea = Math.Max(maxArea, areaTop);
            }
            return maxArea;
        }
        /// <summary>
        /// Two pointers
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxTrapWater(int[] height)
        {
            var rse = 0;
            var max = 0;
            var left = 0;
            var right = height.Length - 1;
            while (left < right)
            {
                if (height[left] < height[right])
                {
                    max = Math.Max(max, height[left]);
                    rse += max - height[left];
                    left++;
                }
                else
                {
                    max = Math.Max(max, height[right]);
                    rse += max - height[right];
                    right--;
                }
            }

            return rse;
        }

        /// <summary>
        /// Loop from left to right Find the highest pointer, 
        /// then calculate trapping water toword two side if there is.
        /// Use stack to do it, scan the array, if we found that the 
        /// current value is >= max in the stack, 
        /// calculate how much water it is able to trap. otherwise, add to stack.
        /// [0,1,0,2,1,0,1,3,2,1,2,1]
        /// 0 add
        /// stack : 0
        /// 1 add(greater than max = 0 in stack, calculate result)
        /// stack: 1    result = (max – 0)
        /// 0 add
        /// stack: 1, 0
        /// 2 add(greater than max = 1 in stack, calculate result)
        /// stack: 2  result = (max – 0) + (max – 1)
        /// 1, 0, 1 add
        /// stack: 2, 1, 0, 1
        /// 3 add(greater than max = 2 in stack, calculate result)
        /// stack: 3 result = (max – 1) + (max – 0) + (max – 1) + (max – 2)
        /// ….
        /// See code for more detailed information.

        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxTrapWaterStack(int[] height)
        {
            var res = 0;
            var stack = new Stack<int>();

            var max = 0;

            for (int i = 0; i < height.Length; i++)
            {
                //if there is higher point at right side
                while (stack.Any() && height[i] >= max)
                {
                    var top = stack.Pop();
                    res += max - height[top];
                }

                stack.Push(i);
                max = Math.Max(max, height[i]);
            }

            var curMax = stack.Any() ? height[stack.Peek()] : 0;
            //move to the left side 
            while (stack.Any())
            {
                var top = stack.Pop();
                if (curMax <= height[top])
                {
                    curMax = height[top];
                }
                else
                {
                    res += curMax - height[top];
                }
            }

            return res;
        }

        /// <summary>
        /// Given an absolute path for a file (Unix-style), simplify it.
        /// For example,
        /// path = "/home/", => "/home".
        /// path = "/a/./b/../../c/", => "/c"
        /// Corner Cases:
        /// •	Did you consider the case where path = "/../" ?
        /// In this case, you should return "/".
        /// •	Another corner case is the path might contain multiple slashes 
        /// '/' together, such as "/home//foo/".
        /// In this case, you should ignore redundant slashes and return 
        /// "/home/foo".
        /// Solution: the solution is simply, if it is ., do nothing, 
        /// if it is .., pop item from stack. 
        /// otherwise push item into stack.the difficult part would be corner cases.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string SimplyPath(string path)
        {
            var mystack = new Stack<string>();
            var tokens = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var token in tokens)
            {
                if (token.Equals("."))
                {
                    continue;
                }
                if (token.Equals(".."))
                {
                    if (mystack.Count > 0)
                    {
                        mystack.Pop();
                    }
                }
                else
                {
                    mystack.Push(token);
                }
            }

            return mystack.Any() ? "/" + mystack.Aggregate((current, str) => str + "/" + current) : "/";

        }


        /// <summary>
        /// Given a string containing just the characters ‘(‘, ‘)’, ‘{‘, ‘}’,
        /// ‘[‘ and ‘]’, determine if the input string is valid.
        ///The brackets must close in the correct order, “()” and “()[]{}” 
        ///are all valid but “(]” and “([)]” are not.
        ///Solution: the rule of parentheses is
        ///1.	if it is left part parentheses((, [,{), then we do not need 
        ///to valid any thing.just put it into stack.
        ///2.  if it is right part parentheses(),],}), then pop the stack 
        ///and it should be the same pair of parentheses. if current is ), 
        ///then the top of stack should be(. otherwise fails.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool ValidPareenthese(string s)
        {
            var stack = new Stack<Char>();

            foreach (var ch in s)
            {
                switch (ch)
                {
                    case '(':
                    case '[':
                    case '{':
                        stack.Push(ch);
                        break;
                    case ')':
                        if (!stack.Any()) return false;
                        var top1 = stack.Pop();
                        if (top1 != '(') return false;
                        break;
                    case ']':
                        if (!stack.Any()) return false;
                        var top2 = stack.Pop();
                        if (top2 != '[') return false;
                        break;
                    case '}':
                        if (!stack.Any()) return false;
                        var top3 = stack.Pop();
                        if (top3 != '{') return false;
                        break;
                    default:
                        return false;
                }
            }

            return !stack.Any();
        }

    }
}
