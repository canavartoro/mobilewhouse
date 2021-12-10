using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

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
    }
}
