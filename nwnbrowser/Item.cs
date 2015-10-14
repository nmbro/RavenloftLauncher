using System.Xml.Serialization;
using System.Windows.Forms;

namespace NWNBrowser
{
    public enum STATUS { UNKNOWN = 0, CHECKING = 1, DOWNLOAD = 2, DOWNLOADING = 3, DONE = 4 };

    public class Item
    {
        [XmlAttribute("name")]
        public string _file;

        [XmlAttribute("crc")]
        public string _crc;

        [XmlIgnore]
        public STATUS status = STATUS.UNKNOWN;

        [XmlIgnore]
        public DataGridViewRow row;

        public Item clone()
        {
            Item i = new Item();
            i._file = this._file;
            i._crc = this._crc;
            i.status = this.status;

            return i;
        }


    }
}
