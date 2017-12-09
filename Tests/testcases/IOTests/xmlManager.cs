using Sh.Framework.Debug;
using Sh.Framework.FileIO;
using System;

namespace Tests.testcases.IOTests
{
    public class xmlManager
    {
        DebugConsole console;

        public xmlManager(DebugConsole Console)
        {
            console = Console;
        }

        public void writeFile()
        {
            thing ting = new thing();
            ting.goes = "skra";

            xml.writeSerializableXML (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "wang.xml", ting.GetType());
            console.write("wrote xml", urgency.comment);
        }
    }

    [Serializable]
    public class thing
    {
        public string goes;       //i know i'm cool
    }
}
