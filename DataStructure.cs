using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewPractice
{
    class DataStructure
    {    
        Dictionary<string, int> myDic = new Dictionary<string, int>();
        Hashtable myHashTab = new Hashtable();
        HashSet<int> myHashSet = new HashSet<int>();
        
        public void DupDictionary ()
        {
            myDic.Add("one", 1);
            myDic.Add("two", 2);
            myDic.Add("three", 3);
            //myDic.Add("two", 2); key is not allow doublicate, exception
            myDic.Add("four", 2);

            Console.WriteLine(string.Format("key: {0}, value: {1}", "one", myDic.FirstOrDefault(c => c.Key=="one")));
            foreach (KeyValuePair<string, int> m in myDic)
            {
                Console.WriteLine(string.Format("key: {0}, value: {1}", m.Key, m.Value));
            }
        }

        public void DupHashTable ()
        {
            
            myHashTab.Add("one", 1);
            myHashTab.Add("two", 2);
            myHashTab.Add("three", 3);
            //myHashTab.Add("two", 2); //key is not allow doublicate, exception
            myHashTab.Add("four", 2);

            Console.WriteLine(string.Format("key: {0}, value: {1}", "one", myHashTab["one"]));
            
            foreach (DictionaryEntry m in myHashTab)
            {
                Console.WriteLine(string.Format("key: {0}, value: {1}",m.Key, m.Value));
            }
        }

        public void DupHashSet ()
        {
            myHashSet.Add(1);
            myHashSet.Add(2);
            myHashSet.Add(3);
            myHashSet.Add(4);
            myHashSet.Add(2); //the duplicated will not added without exception.

            List<int> result = myHashSet.ToList<int>();
            foreach (var i in result)
            {
                Console.WriteLine(i);
            }

            List<int> myList = new List<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(2); //will add it to list
            foreach (var i in myList)
            {
                Console.WriteLine(i);
            }
        }
    }
}
