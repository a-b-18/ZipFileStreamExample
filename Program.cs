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

            // Final zip file
            using (var fs = new FileStream("Export.zip", FileMode.OpenOrCreate))
            {
                using (var archive = new ZipArchive(fs, ZipArchiveMode.Create, true))
                {

                    // Files in zip
                    var file1 = archive.CreateEntry("File1.xml");
                    using (var writer = new BinaryWriter(file1.Open()))
                    {
                        writer.Write(fileContents); // Change fileContents to real XML content
                    }
                    var file2 = archive.CreateEntry("File2.xml");
                    using (var writer = new BinaryWriter(file2.Open()))
                    {
                        writer.Write(fileContents); // Change fileContents to real XML content
                    }

                }
            }
        }
    }
}
