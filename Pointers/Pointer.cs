using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice.Pointers
{
    public class Pointer
    {
        /// <summary>
        /// given a sorted integer array[]
        /// </summary>
        /// <param name="source"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public int FindSubArraySum(int [] arr, int sum, bool isMax)
        {
            int length = isMax ? int.MinValue : int.MaxValue;
            int arrSum = 0;
            for (int start = 0, end =0;  end < arr.Length; end++)
            {
                arrSum += arr[end];
                while (arrSum >= sum && start <= end)
                {
                    length = isMax ? Math.Max(length, end - start + 1) : Math.Min(length, end - start + 1);
                    arrSum -= arr[start++];
                }
            }

            return length;
        }
    }
}
