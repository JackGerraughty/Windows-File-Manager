using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    internal class FileOrganizer
    {
        public static void OrganizeByImportance(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
                return;

            var tier1 = new HashSet<string> { ".docx", ".xlsx", ".pptx", ".pdf", ".txt", ".csv", ".md" }; // Important
            var tier2 = new HashSet<string> { ".cs", ".java", ".py", ".cpp", ".h", ".html", ".js", ".ts", ".json", ".xml", ".sql", ".sh", ".bat" }; // Code

            var files = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories);

            foreach (var filePath in files)
            {
                try
                {
                    var file = new FileInfo(filePath);
                    if (file.DirectoryName == null || file.FullName.StartsWith(Path.Combine(path, "Important")) ||
                        file.FullName.StartsWith(Path.Combine(path, "Code")) ||
                        file.FullName.StartsWith(Path.Combine(path, "Other")))
                        continue;

                    string ext = file.Extension.ToLowerInvariant();
                    string targetFolder = "";

                    if (tier1.Contains(ext))
                        targetFolder = Path.Combine(path, "Important");
                    else if (tier2.Contains(ext))
                        targetFolder = Path.Combine(path, "Code");
                    else
                        targetFolder = Path.Combine(path, "Other");

                    if (!Directory.Exists(targetFolder))
                        Directory.CreateDirectory(targetFolder);

                    string targetPath = Path.Combine(targetFolder, file.Name);

                    if (!File.Exists(targetPath) && file.FullName != targetPath)
                        File.Move(file.FullName, targetPath);
                }
                catch
                {
                    // Ignore errors like permission denied or in-use files
                }
            }
        }

    }
}
