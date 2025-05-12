using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    internal class FileRenamer
    {
        public static void RenameFilesWithSpaces(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
                return;

            var files = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories);

            foreach (var filePath in files)
            {
                try
                {
                    var file = new FileInfo(filePath);
                    if (!file.Name.Contains(" "))
                        continue;

                    string newName = file.Name.Replace(" ", "_");
                    string newPath = Path.Combine(file.DirectoryName, newName);

                    if (!File.Exists(newPath) && file.FullName != newPath)
                        File.Move(file.FullName, newPath);
                }
                catch
                {
                    // Skip files that can't be renamed
                }
            }
        }

    }
}
