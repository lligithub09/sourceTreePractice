using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice.Dynamic
{
    public class DynamicProgram
    {

        #region Fibonacci, recursion, dynamic and bottom-to-up methods
        //calculate Fibonacci: 1, 1, 2, 3, 5, 8 (when size > 2 f(n) = f(n-1) + f(n-1)

        //    / <summary>
        //    / Recursion, Time(n) = O(n^2)
        //    / </summary>
        //    / <param name = "n" ></ param >
        //    / < returns ></ returns >
        public int FibonacciRecur(int n, ref int totalcall)
        {
            int result;
            if (n == 1 || n == 2)
            {
                totalcall++;
                result = 1;
            }
            else
            {
                totalcall++;
                result = FibonacciRecur(n - 2, ref totalcall) + FibonacciRecur(n - 1, ref totalcall);
            }
            return result;
        }

        /// <summary>
        /// dynmic main function, which call recursion funciton T = #call*t <=(2n+1)O(1) = O(2n+1) = O(n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string FibonacciDynamic(int n, ref int totalcall)
        {
            int[] results = new int[n + 1];
            FibnoaccRecurBase(n, ref results, ref totalcall);
            return results[n].ToString();
        }

        /// <summary>
        /// fill intermideate array from right (n) to left (1)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="memo"></param>
        /// <param name="totalcall"></param>
        /// <returns></returns>
        private int FibnoaccRecurBase(int n, ref int[] memo, ref int totalcall)
        {

            if (memo[n] > 0) return memo[n];
            if (n == 1 || n == 2)
            {
                totalcall++;
                memo[n] = 1;
            }
            else
            {
                totalcall++;
                memo[n] = FibnoaccRecurBase(n - 1, ref memo, ref totalcall) + FibnoaccRecurBase(n - 2, ref memo, ref totalcall);
            }
            return memo[n];
        }

        /// <summary>
        /// Assign the value from bottom to up, i.e. from left to right intermide array
        /// </summary>
        /// <param name="n"></param>
        /// <param name="totalcall"></param>
        /// <returns></returns>
        public int FibnoaccBottomToUp(int n, ref int totalcall)
        {
            int[] bottomUp = new int[n + 1];
            totalcall++;
            int result = 0;
            if (n == 1 || n == 2)
            {
                result = 1;
            }
            else
            {
                bottomUp[1] = 1;
                bottomUp[2] = 1;
                for (int i = 3; i <= n; i++)
                {
                    bottomUp[i] = bottomUp[i - 2] + bottomUp[i - 1];
                }
                result = bottomUp[n];
            }

            return result;
        }
        #endregion Fib

        #region Given an unsorted array of integers, find the length of longest increasing subsequence.
        /*For example,
        Given [10, 9, 2, 5, 3, 7, 101, 18],
        The longest increasing subsequence is [2, 3, 7, 101], therefore the length is 4. Note that there may be more than one 
        LIS combination, it is only necessary for you to return the length.
        Your algorithm should run in O(n2) complexity.
        Follow up: Could you improve it to O(n log n) time complexity
         */

        /// <summary>
        /// dynamic programming solution. use dp[i] to indicate longest increasing subsequence (not necessary continuous number) 
        /// end at i. so for each item i, scan all the previous dp[j] and find the max dp[j] + 1 where nums[j] < nums[i]
        /// for example [10, 9, 2, 5, 3, 7, 101, 18] -> 2, 3, 7, 101 (data is not necessary continuous
        /// 
        ///             10  9   2   5   3   7   101 18  1 
        ///     10      1                                   i=1 and j < i 
        ///     9       1   1                               i=2 and j < i                     
        ///     2       1   1   1                           i=3 and j < i
        ///     5       1   1   1   2                       i=4 and j < i //[4] = 5 > [3] = 2
        ///     3       1   1   1   2   2                   i=5 and j < i
        ///     7       1   1   1   2   2   3               i=6 and j < i //[6] = 7 > [5] = 2
        ///     101     1   1   1   2   2   3   4
        ///     18      1   1   1   2   2   3   4   4
        ///     1       1   1   1   2   2   3   4   4   1
        ///     
        ///     j
        /// 
        /// basic concept is record number of data for each [j] has larger than before if the current number[i] > number[j], then plus 1
        /// another case [10, 9, 2, 5, 3, 7, 101, 18, 20, 29, 60, 11] ->[2, 3, 7, 18, 20, 29, 60] or max length 7 either [2, 5, 7, 18, 20, 29, 60] 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            var dp = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                //initialize dp[i] = 1, i.e. comparing itself
                dp[i] = 1;
                //dp[j] records how many number is less than [j] in order
                var iValue = nums[i];
                for (int j = 0; j < i; j++)
                {
                    var jValue = nums[j];
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }

            return dp.Max();
        }

        public int LengthOfLISBinarySearch(int[] nums)
        {
            //BinarySearch has unexpect result if the list is not unsorted.
            //nums = new int[] { 1, 2, 3 }; -> 3
            //nums = new int[] { 3, 2, 1 }; -> 3
            //nums = new int[] { 3, 2, 1, 4 }; -> 2
            if (nums == null || nums.Length == 0) return 0;
            var orderednum = new List<int>();

            foreach (var num in nums)
            {
                var index = orderednum.BinarySearch(num);
                if (index < 0) index = -(index + 1);

                if (index == orderednum.Count) orderednum.Add(num);
                else orderednum[index] = num;
            }

            return orderednum.Count;
        }
        #endregion

        #region matching strings
        /// <summary>
        /// Longest common subsequence
        /// A subsequence is a sequence that can be derived from another sequence by deleting some elements without 
        /// changing the order of the remaining elements. Longest common subsequence (LCS) of 2 sequences is a subsequence, 
        /// with maximal length, which is common to both the sequences.
        /// https://www.hackerrank.com/challenges/dynamic-programming-classics-the-longest-common-subsequence/problem
        /// "abcdaf" vs "acbcf" -> result "abcf"
        /// 
        ///         a   b   c   d   a   f
        ///     0   1   2   3   4   5   6   -> i
        ///  a  1   1   1   1   1   1   1
        ///  c  2   1   1   2   2   2   2
        ///  b  3   1   2   2   2   2   2
        ///  c  4   1   2   3   3   3   3
        ///  f  5   1   2   3   3   3   4
        ///  
        ///  j
        ///  
        /// i = 1 & j=1 -> 5, comparing the first chart 'a' in "abcdaf" with all string "acbcf"  (answer = 1)
        /// i = 2 & j=1 -> 5, comapring the first two chars 'ab' in "abcdaft" with all string "acbcf" (answer =2)
        /// i = 3 & j=1 -> 5, comapring the first three chars 'abc' in "abcdaft" with all string "acbcf" (answer =2)
        /// i = 4 & j=1 -> 5, comapring the first four chars 'abcd' in "abcdaft" with all string "acbcf" (answer =3)
        /// i = 5 & j=1 -> 5, comapring the first five chars 'abcdf' in "abcdaft" with all string "acbcf" (answer =3)
        /// 
        /// logic: if dp[i] == dp[j], then dp[i, j] = dp[i-1, j-1] + 1;
        ///        else dp[i, j] = Max(dp[i-1, j], dp[i, j-1]);
        /// 
        /// "bqdrcvefgh" vs "abcvdefgh" ->{"bdefgh", "bcvefgh"} -> bcvefgh
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public int LCSubsequence(string s1, string s2)
        {
            var len1 = s1.Length;
            var len2 = s2.Length;

            var dp = new int[len1 + 1, len2 + 1];
            for (int i = 1; i <= len1; i++)
            {
                for (int j = 1; j <= len2; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[len1, len2]; //the last value in two dimision array is longest value
        }

        /// <summary>
        /// Longest common substring
        /// i.e. "cgefaaaaaabvbbbbbbp", "hqwaaafavbpbbbbbbb" -> 6 bbbbbb
        ///      "cgefaaaaaabvp", "hqwaaafavbpb" -> 3 aaa
        ///  dp[i-1, j-1] recorder if the previous of [i, j] is equal
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public int LCSubstring(string s1, string s2)
        {
            var res = 0;
            var len1 = s1.Length;
            var len2 = s2.Length;

            var dp = new int[len1, len2];
            for (int i = 0; i < len1; i++)
            {
                for (int j = 0; j < len2; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        if (i == 0 || j == 0)
                        {
                            dp[i, j] = 1;
                        }
                        else
                        {
                            dp[i, j] = dp[i - 1, j - 1] + 1;
                        }

                        res = Math.Max(res, dp[i, j]);
                    }
                    else
                    {
                        dp[i, j] = 0;
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// Longest palindromic
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public int LPS(string s)
        {
            var len = s.Length;

            var dp = new int[len, len];
            for (int i = 0; i < len; i++)
            {
                dp[i, i] = 1;
            }

            for (int l = 2; l <= len; l++)
            {
                for (int i = 0; i < len - l + 1; i++)
                {
                    var j = i + l - 1;
                    if (s[i] == s[j])
                    {
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[0, len - 1];
        }

        #endregion
        //short path
    }
}
