using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileManager
{
    internal class FileCorruptionChecker
    {
        public static void ShowSuspiciousFiles(string path, Label outputLabel)
        {
            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
            {
                SetLabel(outputLabel, "Invalid or missing path.");
                return;
            }

            var suspiciousExtensions = new HashSet<string>
            {
                ".exe", ".bat", ".cmd", ".vbs", ".js", ".ps1", ".scr", ".dll"
            };

            var badFolders = new[] { "temp", "downloads", "appdata", "cache" };
            var flagged = new List<FileInfo>();

            try
            {
                var files = EnumerateAllFilesSafe(path);

                foreach (var filePath in files)
                {
                    try
                    {
                        var file = new FileInfo(filePath);
                        string nameLower = file.Name.ToLowerInvariant();
                        string fullPathLower = file.FullName.ToLowerInvariant();
                        string ext = file.Extension.ToLowerInvariant();

                        bool isSuspiciousExt = suspiciousExtensions.Contains(ext);
                        bool isInShadyFolder = badFolders.Any(folder =>
                            fullPathLower.Contains(Path.DirectorySeparatorChar + folder));
                        bool hasMultipleDots = file.Name.Count(c => c == '.') > 1;
                        bool looksRandom = file.Name.Length > 12 && !file.Name.Any(char.IsWhiteSpace) &&
                                           file.Name.Take(8).Count(char.IsDigit) > 5;

                        if (isSuspiciousExt || isInShadyFolder || hasMultipleDots || looksRandom)
                        {
                            flagged.Add(file);
                        }
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                SetLabel(outputLabel, "Error: " + ex.Message);
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine("⚠️ Potentially suspicious or harmful files:");

            foreach (var file in flagged)
                sb.AppendLine(file.FullName);

            SetLabel(outputLabel, sb.ToString());
        }

        private static void SetLabel(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new MethodInvoker(() => label.Text = text));
            }
            else
            {
                label.Text = text;
            }
        }

        private static IEnumerable<string> EnumerateAllFilesSafe(string root)
        {
            var stack = new Stack<string>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                string currentDir = stack.Pop();

                string[] subDirs;
                try
                {
                    subDirs = Directory.GetDirectories(currentDir);
                }
                catch
                {
                    continue; // Skip folders we can't access
                }

                foreach (var sub in subDirs)
                    stack.Push(sub);

                string[] files;
                try
                {
                    files = Directory.GetFiles(currentDir);
                }
                catch
                {
                    continue; // Skip files we can't read in that folder
                }

                foreach (var file in files)
                    yield return file;
            }
        }

    }
}
