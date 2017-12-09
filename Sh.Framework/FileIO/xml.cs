using System;
using System.IO;
using System.Xml.Serialization;

namespace Sh.Framework.FileIO
{
    public static class xml
    {
        public static void writeSerializableXML(string directory, string filename, Type t)
        {
            string path = directory + @"\" + filename;

            XmlSerializer writer = new XmlSerializer(t);
            FileStream fs = File.Create(path);

            writer.Serialize(fs, t);
        }
    }
}
