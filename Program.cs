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
            var files = new Dictionary<string, string>
            {
                {"File1.txt", "1 is the 1."},
                {"File2.txt", "2 is the 2."},
                {"File3.txt", "3 is the 3."},
                {"File4.txt", "4 is the 4."},
                {"File5.txt", "5 is the 5."},
                {"File6.txt", "6 is the 6."},
            };

            // Create zip
            using (var fs = new FileStream("Export.zip", FileMode.OpenOrCreate))
            {
                using (var archive = new ZipArchive(fs, ZipArchiveMode.Create, true))
                {
                    foreach (var file in files)
                    {
                        // Create files in zip
                        var file1 = archive.CreateEntry(file.Key);
                        using (var writer = new StreamWriter(file1.Open()))
                        {
                            // Write to file
                            writer.Write(file.Value);
                        }
                    }
                }
            }
        }
    }
}
