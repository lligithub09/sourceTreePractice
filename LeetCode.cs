using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice
{
    public class LeetCode
    {

        //Given an array of integers, return indices of the two numbers such that they add up to a specific target.
        public int[] TwoSumByHash(int[] nums, int target)
        {
            int[] retIndecis = {0, 0};
            Hashtable hsNums = new Hashtable();
            hsNums.Clear();
            //i is the latter index
            for (var i = 0; i < nums.Length; i++)
            {
                var targetKey = target - nums[i];
                //if targetKey exist
                if (hsNums.ContainsKey(targetKey))
                {
                    retIndecis[1] = i + 1;
                    retIndecis[0] = (int) hsNums[targetKey];
                    return retIndecis;
                }
                //key is the number and value is the index,filter the number which has existed
                if (!hsNums.ContainsKey(nums[i]))
                    hsNums.Add(nums[i], i + 1);
            }
            return (retIndecis);
        }

        public int[] TwoSumByDictionary(int[] nums, int target)
        {
            var retIndices = new int[] {0, 0};
            var result = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                var key = target - nums[i];

                if (result.ContainsKey(nums[i]))
                {
                    retIndices[0] = result[nums[i]];
                    retIndices[1] = i + 1;
                }
                else
                {
                    result.Add(key, i+1);
                }
            }

            return retIndices;
        }

        //
        //While perform operations Dictionary is faster because there is no boxing/unboxing (valuetypes don't need boxing) while in Hashtable boxing/unboxing 
        //(valuetypes need boxing) will happened and which may have memory consumption as well as performance penalties.
        //Another important difference is that Hashtable Hashtable is thread safe for supports multiple reader threads and a single writer thread. 
        //That is the Hashtable allows ONE writer together with multiple readers without locking. In the case of Dictionary there is no thread safety, 
        //if you need thread safety you must implement your own synchronization.

        public LinkedListNode<int> AddTwoNumbers(LinkedListNode<int> l1, LinkedListNode<int> l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            var result = l1;
            l1.Value += l2.Value;

            //for case l1.length >= l2.length
            while (l1.Next != null && l2.Next != null)
            {
                if (l1.Value > 9)
                {
                    l1.Value %= 10;
                    l1.Next.Value += 1;
                }

                l1.Next.Value += l2.Next.Value;

                l1 = l1.Next;
                l2 = l2.Next;
            }

            //if l2.length > l1.length
            if (l2.Next != null)
            {
                l1.Next.Value = l2.Next.Value;
            }
            while (l1.Value > 9)
            {
                l1.Value %= 10;
                if (l1.Next == null)
                {
                    //l1.Next = new LinkedListNode<int>(1);
                    
                }
                else
                {
                    l1.Next.Value++;
                    l1 = l1.Next;
                }

            }

            return result;
        }

        //search the paralmin string
        public bool IsPrStrByLooping(string input)
        {
            var len = input.Length;
            for (int i = 0, j = len - 1; i < j; i++, j--)
            {
                if (input[i] != input[j])
                    return false;
            }
            return true;
        }

        public bool IsPrByRecr(string input)
        {
            if (input.Length <= 1)
                return true;
            return input[0] == input[input.Length - 1] &&  IsPrByRecr(input.Substring(1, input.Length - 2));
        }

        public bool IsAnagram(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
                return false;
            if (s1.Length != s2.Length)
                return false;
            int [] position = new int[256];
            foreach (var s in s1)
            {
                position[s]++;
            }
            foreach (var s in s2)
            {
                position[s]--;
                if (position[s] < 0)
                    return false;
            }

            return true;
        }



        // XOR returns no.of bits that are not same at corresponding positions
        // 2- 0010 and 6 - 0110. Both integers differ at positions (left to right) 3. 2 ^ 6 = 0010 ^ 0110 = 0100
        // You may notice the 1 in the result.
        // Now if we could calculate all those 1's from the result above we get the hamming distance

        // Any two consecutive numbers when written in base2 always differ by either
        // only one bit or differ by all bits - Ex 10000 (16) and 1111(15) differ by all bits
        // (ignore leading zeros) and 1111 (15) 1110(14) differ by 1.Doing & operation on the result
        //continuously will exhaust all 1s and leads to zero. If we want to calculate number of bits in
        //4...0100(4) & 0011(3) becomes zero by then n is incremented by 1 which is our answer

        public int HammingDistince(int x, int y)
        {
            var hd = 0;
            var z = x ^ y;
            while (z > 0)
            {
                z = z & (z - 1);
                hd++;
            }
            return hd;
        }
    }
}
