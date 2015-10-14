using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace Launcher
{
    [XmlRoot("config")]
    public class Configuration
    {
        [XmlIgnore]
        private const string config = "configuration.xml";

        [XmlElement("NeverwinterNights")]
        public string nwninstall = "";

        [XmlElement("Debugging")]
        public bool debugging = false;

        public static Configuration Load()
        {
            Configuration conf = new Configuration();

            try
            {
                using (FileStream reader = new FileStream("configuration.xml", FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Configuration));

                    conf = xmlSerializer.Deserialize(reader) as Configuration;
                }
            }
            catch (FileNotFoundException ex) { }
            catch (Exception ex) { MessageBox.Show("Error; " + ex.Message); }

            conf.Save();

            return conf;
        }

        public void Save()
        {
            using (FileStream writer = new FileStream("configuration.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Configuration));

                xmlSerializer.Serialize(writer, this);
            }
        }
    }
}
