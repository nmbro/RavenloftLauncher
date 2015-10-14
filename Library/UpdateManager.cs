using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using SevenZip;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Library
{
    public class UpdateManager
    {
        #region Singleton
        private static volatile UpdateManager instance;
        private static object syncRoot = new Object();

        private UpdateManager() { }

        public static UpdateManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new UpdateManager();
                        }
                    }
                }

                return instance;
            }
        }
        #endregion

        private static string _updatePath;
        private static Collection _collections;
        private static List<FileCollection> _downloadcollections = new List<FileCollection>();
        private static MarkJohansen.Forms.MSJProgressBar _progressVerify;
        private static MarkJohansen.Forms.MSJProgressBar _progressTotalDownload;
        private static MarkJohansen.Forms.MSJProgressBar _progressFileDownload;
        private static MarkJohansen.Forms.MSJTextBox _loggingTxt;
        private const string webRepository = "http://potm.markjohansen.dk/content/";
        private delegate void setCallBack(string s, bool timestamp);

        public void DownloadSchema()
        {
            try
            {
                WebClient client = new WebClient();
                string content = client.DownloadString(@"http://potm.markjohansen.dk/content/packages.xml");

                XmlSerializer serializer = new XmlSerializer(typeof(Collection));

                using (StringReader reader = new StringReader(content))
                {
                    _collections = (Collection)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex) { }
        }

        public Collection GetCollection
        {
            get { return _collections; }
        }

        public MarkJohansen.Forms.MSJProgressBar ProgressVerify
        {
            get { return _progressVerify; }
            set { _progressVerify = value; }
        }

        public MarkJohansen.Forms.MSJProgressBar ProgressTotalDownload
        {
            get { return _progressTotalDownload; }
            set { _progressTotalDownload = value; }
        }

        public MarkJohansen.Forms.MSJProgressBar ProgressFileDownload
        {
            get { return _progressFileDownload; }
            set { _progressFileDownload = value; }
        }

        public MarkJohansen.Forms.MSJTextBox LoggingArea
        {
            get { return _loggingTxt; }
            set { _loggingTxt = value; }
        }

        public List<FileCollection> SetDownload
        {
            set { _downloadcollections = value; }
        }

        public string UpdatePath
        {
            get { return _updatePath; }
            set { _updatePath = value; }
        }

        public void BuildFiles()
        {
            //check if the updatepath is set and if the directory exists.
            if (_updatePath != null && Directory.Exists(_updatePath))
            {
                //clear our the information
                _collections = new Collection();

                //asdasd
                if (!Directory.Exists(_updatePath + "\\output"))
                {
                    Directory.CreateDirectory(_updatePath+"\\output");
                }

                //get the directory information
                DirectoryInfo directory = new DirectoryInfo(_updatePath);

                //get the dir length
                int dirLength = _updatePath.Length;

                //run though each folder
                foreach (DirectoryInfo d in directory.GetDirectories())
                {
                    if (d.Name != "output")
                    {
                        //ask the collection to find the files
                        FileCollection c = FileCollection.Build(d);

                        //run though each files
                        foreach (FileItem f in c.Files)
                        {
                            //initiate a CRC object
                            CRC32 crc = new CRC32();

                            //build the stringname
                            string FullPath = _updatePath + "\\" + c.Name + f.Directory + f.Filename;

                            //write
                            Console.WriteLine("[FILE]          : " + FullPath);

                            //open a link to the file
                            using (Stream reader = new FileStream(FullPath, FileMode.Open, FileAccess.Read))
                            {
                                //go though each byte
                                foreach (byte b in crc.ComputeHash(reader))
                                {
                                    //build the crc string
                                    f.FileCRC += b.ToString("x2").ToLower();
                                }
                            }

                            //write
                            Console.WriteLine("[FILE-CRC]      : " + f.FileCRC);

                            //output file
                            string outputDir = _updatePath + "\\output" + f.Directory;
                            string outputFile = outputDir + f.Filename + ".7z";
                            Directory.CreateDirectory(outputDir);

                            //start archiving the file
                            SevenZipCompressor.SetLibraryPath("7z.dll");
                            SevenZipCompressor zip = new SevenZipCompressor();
                            zip.CompressionMethod = CompressionMethod.Lzma2;
                            zip.CompressionLevel = CompressionLevel.Ultra;
                            zip.CompressionMode = CompressionMode.Create;

                            Console.WriteLine("[COMPRESS-FROM] : " + FullPath);
                            Console.WriteLine("[COMPRESS-TO]   : " + outputDir + f.Filename + ".7z");
                            zip.CompressFiles(outputFile, FullPath);


                            //initiate a CRC object
                            CRC32 crc2 = new CRC32();

                            f.ArchiveCRC = "";

                            //open a link to the file
                            using (Stream reader = new FileStream(outputFile, FileMode.Open, FileAccess.Read))
                            {
                                //go though each byte
                                foreach (byte b in crc2.ComputeHash(reader))
                                {
                                    //build the crc string
                                    f.ArchiveCRC += b.ToString("x2").ToLower();
                                }
                            }
                            Console.WriteLine("[ARCHIVE-CRC]   : " + f.ArchiveCRC);

                            Console.WriteLine();
                        }

                        //add the collection to the group
                        _collections.Collections.Add(c);
                    }
                }

                XmlSerializer serializer = new XmlSerializer(typeof(Collection));

                using (Stream stream = File.OpenWrite(_updatePath+@"\output\packages.xml"))
                {
                    serializer.Serialize(stream, _collections);
                }
            }
        }

        public void UpdateFiles()
        {
            List<FileItem> files = new List<FileItem>();
            List<FileItem> filesDownload = new List<FileItem>();

            FileInfo fileinfo = new FileInfo(_updatePath);

            foreach (FileCollection col in _downloadcollections)
            {
                files.AddRange(col.Files);
            }

            AddToLog(files.Count + " files marked for check.");

            _progressVerify.Maximum = files.Count;
            _progressVerify.Value = 0;
            _progressTotalDownload.Value = 0;
            _progressFileDownload.Value = 0;


            if (Library.SystemSettings.isDebuggingEnabled)
            {
                this.AddToLog("Starting file check", false);
            }

            foreach (FileItem f in files)
            {
                //build the stringname
                string FullPath = fileinfo.DirectoryName + f.Directory + f.Filename;

                if (File.Exists(FullPath))
                {
                    //initiate a CRC object
                    CRC32 crc = new CRC32();

                    //check debug settings
                    if (Library.SystemSettings.isDebuggingEnabled)
                    {
                        this.AddToLog("      File: " + FullPath);
                    }
                    else
                    {
                        this.AddToLog(f.Directory + f.Filename);
                    }

                    //the file crc
                    string fileCRC = "";

                    //open a link to the file
                    using (Stream reader = new FileStream(FullPath, FileMode.Open, FileAccess.Read))
                    {
                        //go though each byte
                        foreach (byte b in crc.ComputeHash(reader))
                        {
                            //build the crc string
                            fileCRC += b.ToString("x2").ToLower();
                        }
                    }

                    //check debug settings
                    if (Library.SystemSettings.isDebuggingEnabled)
                    {
                        this.AddToLog("System CRC: " + fileCRC);
                        this.AddToLog("   XML CRC: " + f.FileCRC);
                    }

                    //check if they are matching
                    if (fileCRC != f.FileCRC)
                    {
                        filesDownload.Add(f);

                        if (Library.SystemSettings.isDebuggingEnabled)
                        {
                            this.AddToLog("    Status: Marked for download");
                            this.AddToLog("", false);
                        }
                    }
                    else
                    {
                        if (Library.SystemSettings.isDebuggingEnabled)
                        {
                            this.AddToLog("    Status: No action required");
                            this.AddToLog("", false);
                        }
                    }
                    
                }
                else
                {
                    filesDownload.Add(f);

                    if (Library.SystemSettings.isDebuggingEnabled)
                    {
                        this.AddToLog("      File: " + FullPath);
                        this.AddToLog("    Status: Marked for download");
                        this.AddToLog("", false);
                    }
                    else
                    {

                        this.AddToLog(f.Directory + f.Filename);
                    }
                }

                _progressVerify.Value += 1;
            }

            _progressTotalDownload.Maximum = filesDownload.Count;
            _progressTotalDownload.Value = 0;

            if (Library.SystemSettings.isDebuggingEnabled)
            {
                this.AddToLog("", false);
                this.AddToLog("Starting file download.");
            }

            this.AddToLog(filesDownload.Count + " files marked for download.");

            foreach (FileItem f in filesDownload)
            {
                //Build the pathstring
                string FullDirPath = fileinfo.DirectoryName + f.Directory;
                string FullFilePath = FullDirPath + f.Filename;

                using (WebClient webClient = new WebClient())
                {
                    //initiate a CRC object
                    CRC32 crc = new CRC32();

                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);

                    try
                    {
                        string url = (webRepository + f.Directory + f.Filename).Replace('\\', '/');

                        if (!Directory.Exists(FullDirPath))
                        {
                            Directory.CreateDirectory(FullDirPath);
                        }

                        this.AddToLog("Downloading " + f.Directory + f.Filename + ".7z");
                        webClient.DownloadFileAsync(new Uri(url), FullFilePath+".7z");

                        if (Library.SystemSettings.isDebuggingEnabled)
                        {
                            this.AddToLog("            Waiting for download to finish");
                        }

                        while (webClient.IsBusy) { }

                        if (Library.SystemSettings.isDebuggingEnabled)
                        {
                            this.AddToLog("            Download finished");
                        }

                        //start deflateing the file
                        SevenZipExtractor.SetLibraryPath("7z.dll");

                        SevenZipExtractor zip = new SevenZipExtractor(FullFilePath + ".7z");

                        if (File.Exists(FullFilePath + ".7z"))
                        {
                            //make sure the CRC is new
                            CRC32 crc2 = new CRC32();

                            //the file crc
                            string fileCRC = "";

                            //log
                            this.AddToLog("Checking local archive CRC...");

                            //open a link to the file
                            using (Stream reader = new FileStream(FullFilePath + ".7z", FileMode.Open, FileAccess.Read))
                            {
                                //go though each byte
                                foreach (byte b in crc2.ComputeHash(reader))
                                {
                                    //build the crc string
                                    fileCRC += b.ToString("x2").ToLower();
                                }
                            }

                            if (f.ArchiveCRC == fileCRC)
                            {
                                try
                                {
                                    if (Library.SystemSettings.isDebuggingEnabled)
                                    {
                                        this.AddToLog("Extracting :" + FullFilePath + ".7z");
                                    }
                                    zip.ExtractArchive(FullDirPath);

                                    if (File.Exists(FullFilePath))
                                    {
                                        //make sure the CRC is new
                                        CRC32 crc3 = new CRC32();

                                        //the file crc
                                        fileCRC = "";

                                        this.AddToLog("Checking local file CRC...");

                                        //open a link to the file
                                        using (Stream reader = new FileStream(FullFilePath, FileMode.Open, FileAccess.Read))
                                        {
                                            //go though each byte
                                            foreach (byte b in crc3.ComputeHash(reader))
                                            {
                                                //build the crc string
                                                fileCRC += b.ToString("x2").ToLower();
                                            }
                                        }

                                        //check if they are matching
                                        if (fileCRC != f.FileCRC)
                                        {
                                            this.AddToLog("[Error] File CRC did't match expected crc.");

                                            File.Delete(FullFilePath);

                                            //check debug settings
                                            if (Library.SystemSettings.isDebuggingEnabled)
                                            {
                                                this.AddToLog("System CRC: " + fileCRC);
                                                this.AddToLog("   XML CRC: " + f.FileCRC);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        this.AddToLog("[Error] Unable to locate extracted file.");
                                        this.AddToLog("[Error] Local : " + FullFilePath);
                                        this.AddToLog("[Error] Remote: " + url);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                this.AddToLog("[Error] CRC on local archive dosen't match.");
                                this.AddToLog("[Error] System CRC: " + fileCRC);
                                this.AddToLog("[Error]    XML CRC: " + f.FileCRC);
                            }

                            //clean up after ourselves.
                            File.Delete(FullFilePath + ".7z");
                        }
                    }
                    catch (WebException ex)
                    {
                        this.AddToLog("Error: " + ex.Message);
                    }
                }

                _progressTotalDownload.Value += 1;
            }

            this.AddToLog("");
            this.AddToLog("System update finished..");
            if (this.LoggingArea.Text.Contains("error"))
            {
                this.AddToLog("The log contains errors, please check the error log.");
                this.AddToLog("If the system have made an CRC error, please try");
                this.AddToLog("updateing the system again. If the error persist then");
                this.AddToLog("please notify me though mail (mark.s.johansen@gmail.com)");
                this.AddToLog(" or PM on the forum (msjohansen / Mark Johansen)");
            }

            this.AddToLog("");
            this.AddToLog("Did you have problems? try hitting F8 and try again.");
        }

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            _progressFileDownload.setValue(e.ProgressPercentage);
        }

        public void AddToLog(string line, bool timestamp=true)
        {

            if (_loggingTxt.InvokeRequired)
            {
                setCallBack d = new setCallBack(AddToLog);
                _loggingTxt.Invoke(d, new object[] { line, timestamp });
            }
            else
            {
                if (timestamp)
                {
                    DateTime time = DateTime.Now;

                    line = "[" + time.ToString("HH:mm:ss") + "] " + line + "\n";
                }

                _loggingTxt.AppendText(line);
            }
        }
    }
}

