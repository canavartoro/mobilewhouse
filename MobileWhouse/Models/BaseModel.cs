using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Xml;

namespace MobileWhouse.Models
{
    public class BaseModel
    {
        public string ToXml()
        {
            string xmldata = null;
            using (StringWriter stringWriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(GetType());
                serializer.Serialize(stringWriter, this);
                xmldata = stringWriter.ToString();
                Debug.WriteLine(xmldata);
            }
            return xmldata;
        }

        public static object FromXml(Type type, string xmldata)
        {
            if (string.IsNullOrEmpty(xmldata)) return null;

            Debug.WriteLine(xmldata);

            XmlSerializer serializer = new XmlSerializer(type);
            using (StringReader reader = new StringReader(xmldata))
            {
                return serializer.Deserialize(reader);
            }
        }

        public string Serialize(object obj)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
            serializer.Serialize(stream, obj);
            stream = (MemoryStream)writer.BaseStream;
            return encoding.GetString(stream.ToArray(), 0, Convert.ToInt32(stream.Length));
        }

        public static object XmlDeserialize(Type type, string xml)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            XmlSerializer serializer = new XmlSerializer(type);
            MemoryStream stream = new MemoryStream(encoding.GetBytes(xml));
            return serializer.Deserialize(stream);
        }
    }
}
