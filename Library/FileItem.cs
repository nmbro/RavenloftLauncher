using System.Xml.Serialization;
using System.IO;
using SevenZip;

namespace Library
{
    [XmlRoot("file")]
    public class FileItem
    {
        private string _filename = "";
        private string _directory = "";
        private string _archiveCRC = "";
        private string _fileCRC = "";
        private Action _action = Action.Download;

        public FileItem() { }
        
        public FileItem(FileInfo info)
        {
            this.Filename = info.Name;
            this.Directory = info.DirectoryName +"\\";
        }

        [XmlAttribute("directory")]
        public string Directory
        {
            get { return _directory; }
            set { _directory = value; }
        }

        [XmlAttribute("filename")]
        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

        [XmlAttribute("archive")]
        public string ArchiveCRC
        {
            get { return _archiveCRC; }
            set { _archiveCRC = value; }
        }

        [XmlAttribute("file")]
        public string FileCRC
        {
            get { return _fileCRC; }
            set { _fileCRC = value; }
        }

        [XmlAttribute("action")]
        public Action FileAction
        {
            get { return _action; }
            set { _action = value; }
        }
    }

    public enum Action
    {
        [XmlEnum(Name = "Download")]
        Download,
        [XmlEnum(Name = "Delete")]
        Delete
    }
}
