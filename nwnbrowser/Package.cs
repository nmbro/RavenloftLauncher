using System.Collections.Generic;
using System.Xml.Serialization;

namespace NWNBrowser
{
    public class Package
    {
        [XmlElement("file")]
        public List<Item> _items = new List<Item>();

        [XmlAttribute("name")]
        public string _name;

        [XmlAttribute("description")]
        public string _description;
    }
}
