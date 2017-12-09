using System;
using Sh.Framework.FileIO;
using Sh.Framework.Debug;

namespace Tests.testcases.IOTests
{
    public class txtManager
    {
        DebugConsole console;

        public txtManager(DebugConsole Console)
        {
            console = Console;
        }

        public void writeFile()
        {
            bool textwrite = txt.writeFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "shframeworktest.txt", "hello there");
            if (!textwrite)
            {
                throw new Exception("file was not written");
            }

            console.write("wrote file", urgency.comment);
        }

        public void readFile()
        {
            string returntext = txt.readFile (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "shframeworktest.txt", "no file was found");
            console.write(returntext, urgency.comment);
        }
    }
}
