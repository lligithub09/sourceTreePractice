using System;
using System.Diagnostics;
using System.Text;

namespace InterviewPractice
{
    static class ArrayAndString
    {
        public delegate string StringDelegate(string s);

        public delegate bool StringAnagramDelegate(string master, string target);

        public delegate string StringDelegateReturnString(string sa, string sb);

        public static Boolean IsUninquerchars(string str)
        {
            Boolean[] charSet = new bool[256];
            foreach (Char b in str)
            {
                int value = Convert.ToInt32(b);
                if (charSet[value]) return false;
                charSet[value] = true;
            }
            return true;
        }

        #region reverse string
        public static string ReversebyArrary(string str)
        {
           if (str.Length > 0)
           {
               Char[] arr = str.ToCharArray();
               Array.Reverse(arr);
               return new string(arr);
           }
            return null;
        }

        public static string ReversebySb (string str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                sb.Append(str.Substring(str.Length - 1 - i, 1));
            }
            return sb.ToString();
        }

        public static string ReverseXor(string s)
        {
            char[] charArray = s.ToCharArray();
            int len = s.Length - 1;

            for (int i = 0; i < len; i++, len--)
            {
                charArray[i] ^= charArray[len];
                charArray[len] ^= charArray[i];
                charArray[i] ^= charArray[len];
            }
            return new string(charArray);
        }

        public static string ReverseUnicod(string input)
        {
            if (input == null) return null;

            // allocate a buffer to hold the output
            char[] output = new char[input.Length];
            for (int outputIndex = 0, inputIndex = input.Length - 1; outputIndex < input.Length; outputIndex++, inputIndex--)
            {
                // check for surrogate pair
                if (input[inputIndex] >= 0xDC00 && input[inputIndex] <= 0xDFFF &&
                        inputIndex > 0 && input[inputIndex - 1] >= 0xD800 && input[inputIndex - 1] <= 0xDBFF)
                {
                    // preserve the order of the surrogate pair code units
                    output[outputIndex + 1] = input[inputIndex];
                    output[outputIndex] = input[inputIndex - 1];
                    outputIndex++;
                    inputIndex--;
                }
                else
                {
                    output[outputIndex] = input[inputIndex];
                }
            }

            return new string(output);
        }
        #endregion

        public static void Benchmark(string description, StringDelegate d, int times, string text)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int j = 0; j < times; j++)
            {
                d(text);
            }
            sw.Stop();
            Console.WriteLine("{0} Ticks {1} : called {2} times.", sw.ElapsedTicks, description, times);
        }

        public static void Benchmark(string description, StringAnagramDelegate d, int times, string master, string target)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int j = 0; j < times; j++)
            {
                d(master,target);
            }
            sw.Stop();
            Console.WriteLine("{0} Ticks {1} : called {2} times.", sw.ElapsedTicks, description, times);
        }

        public static void Benchmarka(string description, StringDelegateReturnString d, int times, string strA, string strB)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int j = 0; j < times; j++)
            {
                d(strA, strB);
            }
            sw.Stop();
            Console.WriteLine("{0} Ticks {1} : called {2} times.", sw.ElapsedTicks, description, times);
        }


        #region method to remove the duplicated chars
        public static string RemoveDuplicateCharsNormal (string str)
        {
            string results = string.Empty;
            if (string.IsNullOrEmpty(str)) return null;
            if (str.Length == 1) return str;
            foreach (var chr in str)
            {
                if (results.IndexOf(chr) == -1)
                {
                    results = results + chr;
                }
            }
            return results;
        }

        public static string RemoveDuplicateCharsArray(string str)
        {
            string results = string.Empty;
            bool[] charSet = new bool[256];
            int index = 0;
            foreach (var chr in str)
            {
                index = Convert.ToInt32(chr);
                if (!charSet[index])
                {
                    charSet[index] = true;
                    results = results + chr;
                }
            }

            return results;
        }
        #endregion

        #region check anagrams
        public static bool CheckAnagramByArraySort (string master, string target)
        {
            if (string.IsNullOrEmpty(master) || string.IsNullOrEmpty(target)) return false;
            if (master.Trim().Length != target.Trim().Length) return false;
            var masterArr = master.Trim().ToCharArray();
            var targetArr = target.Trim().ToCharArray();
            Array.Sort(masterArr);
            Array.Sort(targetArr);
            return String.Compare(new string(masterArr), new string(targetArr), false) == 0;

        }

         public static bool CheckAnagramByCharCnt (string master, string target)
         {
             if (string.IsNullOrEmpty(master) || string.IsNullOrEmpty(target)) return false;
             if (master.Trim().Length != target.Trim().Length) return false;

             int[] targetLetters = new int[256];
             int[] masterLetters = new int[256];
             foreach (Char chr in master)
             {
                 if (masterLetters[Convert.ToInt32(chr)] == 0) masterLetters[Convert.ToInt32(chr)]++;
             }

             foreach (Char chr in target)
             {
                 if (targetLetters[Convert.ToInt32(chr)] == 0) targetLetters[Convert.ToInt32(chr)]++;
             }

             for (int i = 0; i < targetLetters.Length; i++)
             {
                 if(targetLetters[i] != masterLetters[i]) return false;
             }
             return true;
         }
        #endregion

         #region string.replace/stringbuilder replace
         public static string ReplaceCharbyString(string original, string replace)
         {
             if (string.IsNullOrEmpty(original)) return null;
             var re = original.Replace(" ", replace);
             return re;
         }

        public static string ReplaceCharbyStringBuilder(string original, string replace)
        {
            if (string.IsNullOrEmpty(original)) return null;
            var sb = new StringBuilder(original);
            sb.Replace(" ", replace);
            return sb.ToString();
        }
        #endregion

        #region Mtarix/2d diminsion array
        public static void SetZeros (ref int [,] array2D)
        {
            int[] row = new int[array2D.GetLength(0)];
            int[] column = new int[array2D.GetLength(1)];

            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    if (array2D[i,j] == 0)
                    {
                        row[i] = 1;
                        column[j] = 1;
                    }
                }
            }

            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    if(row[i] == 1 || column[j] == 1)
                    {
                        array2D[i,j] = 0;
                    }
                }
            }
        }
        #endregion

        #region check string rotataion i.e apple -> pleap (pleap+pleap = pleappleap)
        public static bool CheckWordRotation (string master, string target)
        {
            if (string.IsNullOrEmpty(master) || string.IsNullOrEmpty(target)) return false;
            if (master.Length != target.Length) return false;
            return (target + target).IndexOf(master) > 0;
        }
        #endregion
    }
}
