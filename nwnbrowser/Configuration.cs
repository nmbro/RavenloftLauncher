using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace NWNBrowser
{
    [XmlRoot("Configuration")]
    public class Configuration
    {
        [XmlElement("NeverwinterNightsInstall")]
        public string NeverWinterNightsInstall = "";

        public static Configuration Load()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));

                using (StreamReader reader = new StreamReader("configuration.xml"))
                {
                    return (Configuration)serializer.Deserialize(reader);
                }
            }
            catch (FileNotFoundException up)
            {
                throw up;
            }
        }

        public void Save()
        {
            using (StreamWriter myWriter = new StreamWriter("configuration.xml", false))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(Configuration));
                mySerializer.Serialize(myWriter, this);
            }
        }
    }
}
