using System;
using System.Collections.Generic;

namespace PlayRemoteSoundServer
{

    class DictionaryTest
    {
        private
            static string TestString1 = "Key : Value";
            static string TestString2 = "Key1 : Value \nKey2 : Value \nKey3:";
            static Dictionary<string, string> TestDict1 = new Dictionary<string, string>();
            static Dictionary<string, string> TestDict2 = new Dictionary<string, string>();
            static List<Dictionary<string, string>> Dicts = new List<Dictionary<string, string>>();
        //public static Dictionary<string,string>

        public static void Test()
        {
            string[] temp;
            Console.WriteLine("Test 1:\n");
            //Given the first test stringconvert the first half into the key and the next half into the value
            temp = TestString1.Split(":");
            TestDict1.Add(temp[0], temp[1]);
            //Given the Second string split into string array on each newline
            string[] lines = TestString2.Split("\n");
            //Split each line on : and add the key and value appropriatley
            foreach (string line in lines)
            {
                temp = line.Split(":");
                TestDict2.Add(temp[0], temp[1]);
            }
            //add dicts 
            Dicts.Add(TestDict1);
            Dicts.Add(TestDict2);
            //Loop through each dict and print out the key-pairs
            int iteration = 0;
            foreach (var Dict in Dicts)
            {
                iteration++;
                Console.WriteLine($"Dictionary {iteration}:");
                foreach (var entry in Dict)
                {
                    Console.WriteLine($" Key-{entry.Key}: Value-{entry.Value}");
                }
            }
        }

    }
}
