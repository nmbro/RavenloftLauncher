using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NWNBrowser
{
    [XmlRoot("packages")]
    public class Packages
    {
        [XmlElement("package")]
        public List<Package> _packages = new List<Package>();

        [XmlAttribute("version")]
        public string _version = "";

        [XmlAttribute("generated")]
        public DateTime _generated = DateTime.Now;

        public string ToString()
        {
            int count = 0;

            foreach (Package p in _packages)
            {
                count += p._items.Count;
            }


            return _packages.Count + " Packages with " + count + " items.";
        }
    }
}
