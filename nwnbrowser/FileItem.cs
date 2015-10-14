
namespace NWNBrowser
{
    public class FileItem
    {
        private string filename;
        private string crchash;

        public FileItem(string name, string crc)
        {
            this.filename = name;
            this.crchash = crc;
        }

        public string Filename
        {
            get
            {
                return this.filename;
            }
        }

        public string CRC
        {
            get
            {
                return this.crchash;
            }
        }
    }
}
