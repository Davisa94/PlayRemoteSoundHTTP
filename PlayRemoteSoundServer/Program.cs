 using System;

namespace PlayRemoteSoundServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DictionaryTest.Test();
            Console.WriteLine(FileActions.ConcatFilenameToPath("beans.mp3"));
        }
    }
}
