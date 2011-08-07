using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BuildFetcher
{
    public class XmlDeserialzer<T> where T : class
    {
        protected T DeserializeXml(XDocument jobXml)
        {
            var serializer = new XmlSerializer(typeof(T));
            var reader = jobXml.CreateReader();
            var deserializedJobData = (T)serializer.Deserialize(reader);
            return deserializedJobData;
        }
    }
}
