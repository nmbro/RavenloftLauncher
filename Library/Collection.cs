using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Library
{
    [XmlRoot("collections")]
    public class Collection
    {
        private List<FileCollection> _collections = new List<FileCollection>();
        private DateTime _timestamp = DateTime.Now;

        [XmlElement("timestamp")]
        public DateTime Timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }

        [XmlElement("package")]
        public List<FileCollection> Collections
        {
            get { return _collections; }
            set { _collections = value; }
        }
    }
}
