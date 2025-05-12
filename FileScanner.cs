using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    internal class FileScanner
    {
        public static IEnumerable<FileInfo> GetAllFiles(string rootPath)
        {
            if (string.IsNullOrWhiteSpace(rootPath) || !Directory.Exists(rootPath))
                yield break;

            var root = new DirectoryInfo(rootPath);

            foreach (var file in root.EnumerateFiles("*", SearchOption.AllDirectories))
            {
                yield return file;
            }
        }


        public static void ShowTopLargestFiles(string path, int top = 10)
        {
            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
            {
                Console.WriteLine("Error: Invalid or missing path.");
                return;
            }

            var largest = GetAllFiles(path)
                .OrderByDescending(f => f.Length)
                .Take(top);

            Console.WriteLine($"Top {top} largest files:");
            foreach (var file in largest)
                Console.WriteLine($"{file.FullName} - {file.Length / (1024.0 * 1024.0):F2} MB");
        }


        private static readonly HashSet<string> SuspectExtensions = new HashSet<string>(new[]
        {
            ".log", ".tmp", ".bak", ".old", ".iso", ".zip", ".7z", ".rar"
        }, StringComparer.OrdinalIgnoreCase);


        private static readonly string[] KnownUnimportantFolders = { "temp", "tmp", "downloads", "cache" };

        public static void ShowBiggestUnimportantFiles(string path, Label BiggestFiles, int top = 10)
        {
            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
            {
                if (BiggestFiles.InvokeRequired)
                {
                    BiggestFiles.Invoke(new MethodInvoker(() =>
                        BiggestFiles.Text = "Invalid or missing path."));
                }
                else
                {
                    BiggestFiles.Text = "Invalid or missing path.";
                }
                return;
            }

            var candidateFiles = new List<Tuple<FileInfo, long>>();
            var lockObj = new object(); // for thread-safe list access

            try
            {
                var filePaths = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories);

                Parallel.ForEach(filePaths, filePath =>
                {
                    try
                    {
                        var file = new FileInfo(filePath);
                        string fullPathLower = file.FullName.ToLowerInvariant();
                        string extension = file.Extension != null ? file.Extension.ToLowerInvariant() : "";

                        bool isJunkExt = SuspectExtensions.Contains(extension);
                        bool isInUnimportantFolder = KnownUnimportantFolders.Any(f =>
                            fullPathLower.Contains(Path.DirectorySeparatorChar + f));

                        if (isJunkExt || isInUnimportantFolder)
                        {
                            lock (lockObj)
                            {
                                candidateFiles.Add(Tuple.Create(file, file.Length));
                            }
                        }
                    }
                    catch
                    {
                        // Skip unreadable or locked files
                    }
                });
            }
            catch (Exception ex)
            {
                if (BiggestFiles.InvokeRequired)
                {
                    BiggestFiles.Invoke(new MethodInvoker(() =>
                        BiggestFiles.Text = "Error: " + ex.Message));
                }
                else
                {
                    BiggestFiles.Text = "Error: " + ex.Message;
                }
                return;
            }

            var topFiles = candidateFiles
                .GroupBy(t => t.Item1.FullName)
                .Select(g => g.First())
                .OrderByDescending(t => t.Item2)
                .Take(top);

            var sb = new StringBuilder();
            sb.AppendLine("Top " + top + " possibly unimportant large files:");

            foreach (var tuple in topFiles)
            {
                var file = tuple.Item1;
                var size = tuple.Item2;
                sb.AppendLine(file.FullName + " - " +
                              (size / (1024.0 * 1024.0)).ToString("F2") + " MB");
            }

            if (BiggestFiles.InvokeRequired)
            {
                BiggestFiles.Invoke(new MethodInvoker(() =>
                    BiggestFiles.Text = sb.ToString()));
            }
            else
            {
                BiggestFiles.Text = sb.ToString();
            }
        }



        private static IEnumerable<FileInfo> EnumerateFilesSafe(string root)
        {
            var stack = new Stack<string>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                string currentDir = stack.Pop();
                IEnumerable<string> subDirs = Enumerable.Empty<string>();

                try { subDirs = Directory.EnumerateDirectories(currentDir); } catch { }

                foreach (var sub in subDirs)
                    stack.Push(sub);

                IEnumerable<string> files = Enumerable.Empty<string>();
                try { files = Directory.EnumerateFiles(currentDir); } catch { }
                foreach (var filePath in files)
                {
                    FileInfo info = null;
                    try
                    {
                        info = new FileInfo(filePath);
                    }
                    catch
                    {
                        continue;
                    }

                    // Yield happens *outside* the try
                    if (info != null)
                        yield return info;
                }
            }
        }
    }
}
