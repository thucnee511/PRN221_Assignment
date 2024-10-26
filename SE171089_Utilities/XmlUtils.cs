using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SE171089_Utilities
{
    public class XmlUtils
    {
        public static List<T> ReadXmlFile<T>(String filepath)
        {
            try
            {
                using FileStream file = File.Open(filepath, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                List<T> list = (List<T>)serializer.Deserialize(file);
                return list;
            }
            catch
            {
                return new();
            }
        }

        public static void WriteXmlFile<T>(List<T> list, String filepath)
        {
            using FileStream file = File.Create(filepath);
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            serializer.Serialize(file, list);
        }
    }
}
