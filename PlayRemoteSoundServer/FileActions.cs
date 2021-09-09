using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlayRemoteSoundServer
{
    public class FileActions
    {
        private static readonly Regex sWhitespace = new Regex(@"\s+");
        private static string settingsFileName = "settings.txt";
        private static string defaultSettings = "" +
            "serverPort:5001" +
            "serverAddress:http://localhost" +
            "soundsFolder:";

        public static string ReplaceWhitespace(string input, string replacement)
        {
            return sWhitespace.Replace(input, replacement);
        }
        public static string ConcatFilenameToPath(string filename)
        {
            string path = GetBaseDirectory();

            var finalPath = $"{path}\\{filename}";
            return finalPath;
        }

        public string GetMessage(string fileName)
        {
            string fileContents = System.IO.File.ReadAllText(fileName);
            return fileContents;
        }

        public Dictionary<string, string> ParseSettingsFromFile(string filename, string path = "")
        {
            filename = ConcatFilenameToPath(filename);
            Console.WriteLine("Ensure that the settings.txt are in this directory Then press any key to continue");
            Console.ReadLine();
            Dictionary<string, string> ReturnDict = new Dictionary<string, string>();

            //open file
            //get lines array

            string[] tempArray;
            string tempString;
            Console.WriteLine("Getting Settings From File...");

            var lines = GetFileContents(filename);
            //Strip whitespace and Split each line on : and add the key and value appropriatley
            foreach (string line in lines)
            {
                tempString = ReplaceWhitespace(line, ""); 
                tempArray = tempString.Split(":");
                ReturnDict.Add(tempArray[0], tempArray[1]);
            }
            //Console log it 
            foreach (var entry in ReturnDict)
            {
                Console.WriteLine($" Key-{entry.Key}: Value-{entry.Value}");
            }
            return ReturnDict;
           

        }
        public static void GenerateSettingsFile()
        {
            var path = GetBaseDirectory();
            var fullSettingsFile = ConcatFilenameToPath(settingsFileName);
            if (!File.Exists(fullSettingsFile))
            {

            }

        }

        public static string GetBaseDirectory()
        {
            var path = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine("Detected Running Directory is:" + path);
            return path;
        }

        public static IEnumerable<string> GetFileContents(string filename)
        {
            var lines = File.ReadLines(filename);
            return lines;
        }
        public void EditFile(string filename, string message)
        {
            // what line in the html do we write the action to
            int editLine = 116;
            // path to the html file
            string lineToWrite = null;
            // verify that the line is valid
            using (StreamReader reader = new StreamReader(filename))
            {
                for (int i = 1; i <= editLine; ++i)
                    lineToWrite = reader.ReadLine();
            }

            if (lineToWrite == null)
                throw new InvalidDataException("Line Number" + editLine + " does not exist in " + filename);

            // read the whole file:
            string[] lines = File.ReadAllLines(filename);

            // Write the new file over the old file.
            using (StreamWriter writer = new StreamWriter(filename))
            {
                for (int currentLine = 1; currentLine <= lines.Length; ++currentLine)
                {
                    if (currentLine == editLine)
                    {
                        writer.WriteLine(lineToWrite);
                    }
                    else
                    {
                        writer.WriteLine(lines[currentLine - 1]);
                    }
                }
            }
        }
    }
}
