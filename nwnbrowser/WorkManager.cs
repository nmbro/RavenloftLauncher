using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace NWNBrowser
{
    public sealed class WorkManager
    {
        #region Singleton Class
        private static volatile WorkManager instance;
        private static object syncRoot = new Object();

        private WorkManager() { }

        public static WorkManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new WorkManager();
                    }
                }

                return instance;
            }
        }
        #endregion

        private readonly object queueLock = new object();
        private MainForm form;
        private Repository repo;
        private ConcurrentQueue<Item> queue = new ConcurrentQueue<Item>();
        private Random rnd = new Random();
        private int threadcount = 0;
        private Packages packages;
        private List<Thread> threads = new List<Thread>();

        public void SetForm(MainForm f)
        {
            this.form = f;
        }

        public void StartSlave()
        {
            this.threadcount++;

            Thread t = new Thread(new ThreadStart(this.Work));
            threads.Add(t);
            t.Start();
        }

        private void Work()
        {
            while (!queue.IsEmpty)
            {
                Item f;
                if (queue.TryDequeue(out f))
                {
                    FileInfo file = new FileInfo(this.form.txtNWNInstall.Text.Substring(0, (this.form.txtNWNInstall.Text.Length - 10)) + "\\" + f._file);
                    string addr = (repo.Address +  f._file).Replace('\\', '/');

                    if (File.Exists(file.FullName))
                    {
                        //prepare the check.
                        CRC32 crcCheck = new CRC32();

                        //assign the status.
                        f.row.Cells[1].Value = "Checking";

                        //create the string for the hash.
                        string hash = "";

                        //open the file
                        using (Stream reader = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                        {
                            //calculate the hash and go though each return byte.
                            foreach (byte b in crcCheck.ComputeHash(reader))
                            {
                                //foreach bye add the value to the string.
                                hash += b.ToString("x2").ToLower();
                            }
                        }

                        //check if the hash matches
                        if (hash == f._crc)
                        {
                            f.row.Cells[1].Value = "Not Updated";
                        }
                        //if the file dosen't match add it to download.
                        else
                        {
                            //assign the status.
                            f.row.Cells[1].Value = "Downloading";

                            //mark the file for download.
                            this.download(file, addr, f);
                        }
                    }
                    else
                    {
                        //assign the status.
                        f.row.Cells[1].Value = "Downloading";

                        //mark the file for download.
                        this.download(file, addr, f);
                    }


                }
            }

            if (queue.IsEmpty && threads.FindAll(Thread => Thread.IsAlive).Count == 1)
            {
                this.form.BeginInvoke((MethodInvoker)delegate()
                {
                    this.form.btnUpdate.Enabled = true;
                    this.form.checkedListBox1.Enabled = true;
                    this.form.btnToggleWindow.Enabled = true;
                });
            }
        }

        private void download(FileInfo file, string source, Item f)
        {
            Directory.CreateDirectory(file.DirectoryName);

            try
            {
                WebClientMSJ download = new WebClientMSJ();
                download.item = f;
                download.DownloadProgressChanged += new DownloadProgressChangedEventHandler(download_DownloadProgressChanged);
                download.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(download_DownloadFileCompleted);
                f.row.Cells[1].Value = "Downloading";
                download.DownloadFileAsync(new Uri(source), file.FullName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void download_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            WebClientMSJ client = sender as WebClientMSJ;
            client.item.row.Cells[1].Value = "File Updated";
        }

        void download_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            WebClientMSJ client = sender as WebClientMSJ;

            client.item.row.Cells[2].Value = e.ProgressPercentage;
        }

        public void setMirror(Repository r)
        {
            this.repo = r;
        }

        public void AddGroup(string group)
        {
            Package p = packages._packages.Find(Package => Package._name == group);

            foreach (Item i in p._items)
            {
                this.AddFile(i);
            }
        }

        public void AddFile(Item f)
        {
            f.row.Cells[2].Value = 0;
            this.queue.Enqueue(f);
        }
        
        public void getPackages()
        {
            Thread t = new Thread(new ThreadStart(this.getPackagesFromWeb));
            t.Start();
        }

        private void getPackagesFromWeb()
        {
            try
            {
                //create the serializer
                XmlSerializer serializer = new XmlSerializer(typeof(Packages));

                //create the web request
                WebRequest request = HttpWebRequest.Create(repo.Address + "packages.xml");
                request.Method = "GET";

                //retrive the response
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);

                //get the content
                string xml = reader.ReadToEnd();

                //close the streams
                reader.Close();
                response.Close();

                //create a reader
                StringReader r = new StringReader(xml);

                //deserialize
                packages = (Packages)serializer.Deserialize(r);

                this.form.BeginInvoke((MethodInvoker)delegate()
                {
                    form.checkedListBox1.Items.Clear();

                    foreach (Package p in packages._packages)
                    {
                        form.checkedListBox1.Items.Add(p._name);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("System was unable to retrive package information from the repository, please try another\n" + ex.Message);
            }
        }

        public void RemoveFilesFromView(string group)
        {
            Package p = packages._packages.Find(Package => Package._name == group);

            foreach (Item i in p._items)
            {
                this.form.dataGridView1.Rows.Remove(i.row);
            }
        }

        public void AddFilesToView(string group)
        {
            Package p = packages._packages.Find(Package => Package._name == group);
            
            this.form.dataGridView1.BeginInvoke((MethodInvoker)delegate()
            {
                foreach (Item i in p._items)
                {
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    DataGridViewRow row = new DataGridViewRow();

                    DataGridViewTextBoxCell filename = new DataGridViewTextBoxCell();
                    filename.Value = i._file;
                    row.Cells.Add(filename);

                    DataGridViewTextBoxCell status = new DataGridViewTextBoxCell();
                    status.Value = "Unknown";
                    status.Style = style;
                    row.Cells.Add(status);

                    DataGridViewProgressCell download = new DataGridViewProgressCell();
                    download.Value = 0;
                    row.Cells.Add(download);

                    i.row = row;

                    this.form.dataGridView1.Rows.Add(row);
                }
            });
        }
    }
}
