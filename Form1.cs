using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class Form1 : Form
    {
        private Timer _uiTimer;
        private string _targetPath;
        public Form1()
        {

            InitializeComponent();

            // Example: hardcoded or from a UI element
            _targetPath = textBox1.Text;

            _uiTimer = new Timer();
            _uiTimer.Interval = 50 * 60 * 1000; // 50 minutes
            _uiTimer.Tick += async (s, e) => await RunFileTasksAsync();
            _uiTimer.Start();

        }

        private async Task RunFileTasksAsync()
        {
            try
            {
                // validate path first
                if (string.IsNullOrWhiteSpace(textBox1.Text) || !Directory.Exists(textBox1.Text))
                {
                    MessageBox.Show("Invalid or missing path.");
                    return;
                }
                await Task.Run(() =>
                {
                    FileScanner.ShowTopLargestFiles(_targetPath);
                    FileCorruptionChecker.ShowSuspiciousFiles(_targetPath, BiggestFiles);
                    FileOrganizer.OrganizeByImportance(_targetPath);
                    FileRenamer.RenameFilesWithSpaces(_targetPath);
                    FileScanner.ShowBiggestUnimportantFiles(_targetPath, BiggestFiles);
                });

                AppendLog($"✔ Tasks completed @ {DateTime.Now}");
            }
            catch (Exception ex)
            {
                AppendLog($"❌ Error: {ex.Message}");
            }
        }

        private void AppendLog(string message)
        {
            // Example log output (assume a TextBox named logBox exists)
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => logBox.AppendText(message + Environment.NewLine)));
            }
            else
            {
                logBox.AppendText(message + Environment.NewLine);
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = dialog.SelectedPath;
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileOrganizer.OrganizeByImportance(textBox1.Text);
        }

        private void FileNaming_Click(object sender, EventArgs e)
        {
            FileRenamer.RenameFilesWithSpaces(textBox1.Text);
        }

        private async void CorruptedFileShow_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;

            BiggestFiles.Text = "Scanning for suspicious files...";

            await Task.Run(() =>
            {
                FileCorruptionChecker.ShowSuspiciousFiles(path, BiggestFiles);
            });

        }

        private void BiggestFiles_Click(object sender, EventArgs e)
        {

        }

        private void FileShow_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                FileScanner.ShowBiggestUnimportantFiles(textBox1.Text, BiggestFiles);
            }
            else
            {
                throw new ArgumentException("Folder path must not be empty.");
            }
        }

        private void logBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select a folder to scan";
                dialog.ShowNewFolderButton = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = dialog.SelectedPath;
                }
            }
        }

    }
}
