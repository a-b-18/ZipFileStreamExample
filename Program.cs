using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ByteToBitmap
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            string fileContents = "Lorem ipsum dolor sit amet";

            // Create zip
            using (var fs = new FileStream("Export.zip", FileMode.OpenOrCreate))
            {
                using (var archive = new ZipArchive(fs, ZipArchiveMode.Create, true))
                {

                    // Create files in zip
                    var file1 = archive.CreateEntry("File1.txt");
                    using (var writer = new StreamWriter(file1.Open()))
                    {
                        // Write to file
                        writer.Write(fileContents);
                    }
                    var file2 = archive.CreateEntry("File2.txt");
                    using (var writer = new StreamWriter(file2.Open()))
                    {
                        // Write to file
                        writer.Write(fileContents);
                    }

                }
            }
        }
    }
}
