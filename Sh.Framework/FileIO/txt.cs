using System;
using System.IO;

namespace Sh.Framework.FileIO
{
    public static class txt
    {
        /// <summary>
        /// Writes a single string to a text file using a file path.
        /// Useful for quick writing, not very useful for serialization
        /// </summary>
        /// <param name="path">directory path to write file to (excluding file name itself)</param>
        /// <param name="filename">name of file (including file extension)</param>
        /// <param name="message">what to write in file</param>
        /// <returns>if the file was written or not</returns>
        public static bool writeFile(string path, string filename, string message)
        {
            if (!Directory.Exists(path))
            {
                throw new Exception(path + " does not exist, create it first");
            }
            else
            {
                try
                {
                    File.WriteAllText(path + @"\" + filename, message);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// returns one line of a specified text file
        /// </summary>
        /// <param name="path">directory path to write file to (excluding file name itself)</param>
        /// <param name="filename">name of file (including file extension)</param>
        /// <param name="emergency">what to return if the file does not exist</param>
        /// <returns></returns>
        public static string readFile(string path, string filename, string emergency)
        {
            if (!File.Exists(path + @"\" + filename))
            {
                Console.WriteLine(path + @"\" + filename + " not found, using emergency string instead");
                return emergency;
            }
            else
            {
                return File.ReadAllText(path + @"\" + filename);
            }
        }
    }
}
