 using System;
using System.Collections.Generic;

namespace PlayRemoteSoundServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sanity Checks
            /*Console.WriteLine("Hello World!");
            DictionaryTest.Test();
            Console.WriteLine(FileActions.ConcatFilenameToPath("beans.mp3"));
            FileActions.GenerateSettingsFile();
            FileActions.ParseSettingsFromFile();*/
            Console.WriteLine("Starting Server ....");
            string [] prefixes = { "http://localhost" + ":5051/" };
            HttpSoundServer.SimpleListenerExample(prefixes);
        }
    }
}
