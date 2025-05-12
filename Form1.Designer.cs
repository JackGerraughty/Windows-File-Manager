using System;

namespace FileManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Organize = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.FileNaming = new System.Windows.Forms.Button();
            this.CorruptedFileShow = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BiggestFiles = new System.Windows.Forms.Label();
            this.FileShow = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.BrowseButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(492, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Organizer";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 127);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(481, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(21, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter File Path To Organize";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Organize
            // 
            this.Organize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Organize.Location = new System.Drawing.Point(25, 159);
            this.Organize.Name = "Organize";
            this.Organize.Size = new System.Drawing.Size(104, 45);
            this.Organize.TabIndex = 3;
            this.Organize.Text = "Organize";
            this.Organize.UseVisualStyleBackColor = true;
            this.Organize.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FileNaming
            // 
            this.FileNaming.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FileNaming.Location = new System.Drawing.Point(26, 210);
            this.FileNaming.Name = "FileNaming";
            this.FileNaming.Size = new System.Drawing.Size(222, 45);
            this.FileNaming.TabIndex = 5;
            this.FileNaming.Text = "Improve File Naming";
            this.FileNaming.UseVisualStyleBackColor = true;
            this.FileNaming.Click += new System.EventHandler(this.FileNaming_Click);
            // 
            // CorruptedFileShow
            // 
            this.CorruptedFileShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.CorruptedFileShow.Location = new System.Drawing.Point(26, 261);
            this.CorruptedFileShow.Name = "CorruptedFileShow";
            this.CorruptedFileShow.Size = new System.Drawing.Size(225, 45);
            this.CorruptedFileShow.TabIndex = 6;
            this.CorruptedFileShow.Text = "Show Corrupted Files";
            this.CorruptedFileShow.UseVisualStyleBackColor = true;
            this.CorruptedFileShow.Click += new System.EventHandler(this.CorruptedFileShow_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BiggestFiles);
            this.panel1.Location = new System.Drawing.Point(662, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1095, 673);
            this.panel1.TabIndex = 7;
            // 
            // BiggestFiles
            // 
            this.BiggestFiles.AutoSize = true;
            this.BiggestFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BiggestFiles.Location = new System.Drawing.Point(15, 20);
            this.BiggestFiles.Name = "BiggestFiles";
            this.BiggestFiles.Size = new System.Drawing.Size(0, 33);
            this.BiggestFiles.TabIndex = 0;
            this.BiggestFiles.Click += new System.EventHandler(this.BiggestFiles_Click);
            // 
            // FileShow
            // 
            this.FileShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FileShow.Location = new System.Drawing.Point(26, 312);
            this.FileShow.Name = "FileShow";
            this.FileShow.Size = new System.Drawing.Size(180, 45);
            this.FileShow.TabIndex = 8;
            this.FileShow.Text = "Show Biggest Files";
            this.FileShow.UseVisualStyleBackColor = true;
            this.FileShow.Click += new System.EventHandler(this.FileShow_Click);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(26, 393);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(434, 26);
            this.logBox.TabIndex = 9;
            this.logBox.TextChanged += new System.EventHandler(this.logBox_TextChanged);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(512, 127);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(120, 34);
            this.BrowseButton.TabIndex = 10;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1765, 759);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.FileShow);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CorruptedFileShow);
            this.Controls.Add(this.FileNaming);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Organize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Organize;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button FileNaming;
        private System.Windows.Forms.Button CorruptedFileShow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label BiggestFiles;
        private System.Windows.Forms.Button FileShow;
        private System.Windows.Forms.TextBox logBox;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button BrowseButton;
    }
}

