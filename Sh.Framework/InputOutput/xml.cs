using System;
using System.IO;
using System.Xml.Serialization;

namespace Sh.Framework.InputOutput
{
    public class xml
    {
        /*
        //I might just consider using somebody else's technology instead of writing my own io library

        /// <summary>
        /// Writes a serializable class to an xml file at a given destination
        /// </summary>
        /// <param name="filePath">where to the the file</param>
        /// <param name="obj">the serializable type</param>
        public static void SaveFile(string filePath, Object obj)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(obj.GetType());

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    xs.Serialize(sw, obj);
                }
            }
            catch
            {
                throw new Exception("Something went wrong whilst writing xml");
            }
        }

        /// <summary>
        /// Loads an xml file 
        /// </summary>
        /// <typeparam name="T">serializable type</typeparam>
        /// <param name="filePath">location of xml file</param>
        /// <returns></returns>
        public static T LoadFile <T> (string filePath)
        {
            Object rslt;

            if (File.Exists(filePath))
            {
                var xs = new XmlSerializer(typeof(T));

                using (var sr = new StreamReader(filePath))
                {
                    rslt = (T)xs.Deserialize(sr);
                }
                return (T)rslt;
            }
            else
            {
                return default(T);
            }
        }*/
    }
}
