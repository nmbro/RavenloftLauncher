using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Library
{
    [XmlRoot("filecollection")]
    public class FileCollection
    {
        private List<FileItem> _files = new List<FileItem>();
        private string _name = "asd";

        [XmlAttribute("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [XmlElement("file")]
        public List<FileItem> Files
        {
            get { return _files; }
            set { _files = value; }
        }

        public static FileCollection Build(DirectoryInfo directory)
        {
            int dirLength = directory.FullName.Length;
            FileCollection collection = new FileCollection();
            collection.Name = directory.Name;

            foreach (FileItem file in GetFiles(directory))
            {
                file.Directory = file.Directory.Substring(dirLength);
                collection.Files.Add(file);
            }

            return collection;
        }

        private static List<FileItem> GetFiles(DirectoryInfo directory)
        {
            List<FileItem> files = new List<FileItem>();

            foreach (FileInfo file in directory.GetFiles())
            {
                files.Add(new FileItem(file));
            }

            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                files.AddRange(GetFiles(dir));
            }

            return files;
        }
    }
}
