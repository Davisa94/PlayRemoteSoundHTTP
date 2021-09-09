using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayRemoteSoundServer
{
    public class FileActions
    {
        public static string ConcatFilenameToPath(string filename, string path)
        {
            var finalPath = $"{path}\\{filename}";
            return finalPath;
        }
        public string GetMessage(string fileName)
        {
            string fileContents = System.IO.File.ReadAllText(fileName);
            return fileContents;
        }
        public string[] GetSettingsFromFile(string filename, string path = "")
        {
            return null;
        }
        public static string[] GetFileContents()
        {
            return null;
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
