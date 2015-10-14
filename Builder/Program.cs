using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace Builder
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Console.SetWindowSize(150, Console.WindowHeight);
            UpdateManager manager = UpdateManager.Instance;

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Please select he package directory";

            if (dialog.ShowDialog() != DialogResult.Cancel)
            {
                if (Directory.Exists(dialog.SelectedPath))
                {
                    manager.UpdatePath = dialog.SelectedPath;
                    manager.BuildFiles();
                }
            }
        }
    }
}
