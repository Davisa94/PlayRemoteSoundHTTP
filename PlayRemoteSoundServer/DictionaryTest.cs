using System;
using System.Collections.Generic;

namespace PlayRemoteSoundServer
{

    class DictionaryTest
    {
        private
            string TestString1 = "Key : Value";
            string TestString2 = "Key : Value \nKey : Value \nKey:Value";
            Dictionary<string, string> TestDict1 = new Dictionary<string, string>();
            Dictionary<string, string> TestDict2 = new Dictionary<string, string>();

        //public static Dictionary<string,string>

        public static void Test()
        {

            Console.WriteLine("Test 1:\n");
            //Given the first test stringconvert the first half into the key and the next half into the value

            //Given the Second string split into string array on each newline
            //Split each line on : and add the key and value appropriatley

            //Loop through each dict and print out the key-pairs
        }

    }
}
