using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FolderStatistic
{
    public partial class FolderStatistic : Form
    {
        string selectedFolder;
        public FolderStatistic()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowDialog();
            PathtxtBox.Text = dlg.SelectedPath;
        }

        private void DisplayTopFolderInfo(FileStaticInfo[] lstfileStaticInfo)
        {
            this.gvAll.Rows.Clear();
            DataGridViewRow row = this.gvAll.Rows[this.gvAll.Rows.Add()];
            row.Cells[0].Value = lstfileStaticInfo.Sum(x => x.Count);
            row.Cells[1].Value = lstfileStaticInfo.Sum(x => x.Size);
        }

        private void DisplayAllFileStaticInfo(FileStaticInfo[] lstfileStaticInfo)
        {
            this.gvDetail.Rows.Clear();
            foreach (var fileStaticInfo in lstfileStaticInfo)
            {
                DataGridViewRow row = this.gvDetail.Rows[this.gvDetail.Rows.Add()];
                row.Cells[0].Value = fileStaticInfo.FileType;
                row.Cells[1].Value = fileStaticInfo.Count;
                row.Cells[2].Value = fileStaticInfo.Size;
            }
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            var allFI = Directory.GetFiles(
                this.selectedFolder, "*.*", SearchOption.AllDirectories)
                .Select(x => new FileInfo(x)).ToArray();

            var lstfileStaticInfo = allFI.GroupBy(x => x.Extension)
                .Select(x => new FileStaticInfo(x.Key, x.Count(), x.Sum(y => y.Length)))
                .ToArray();

            this.DisplayAllFileStaticInfo(lstfileStaticInfo);
            this.DisplayTopFolderInfo(lstfileStaticInfo);
        }

        private void PathtxtBox_TextChanged(object sender, EventArgs e)
        {
            this.selectedFolder = this.PathtxtBox.Text.Trim();
            btnStatistic.Enabled = Directory.Exists(this.selectedFolder);
        }
    }

    public struct FileStaticInfo
    {
        public FileStaticInfo(string t, int c, long s)
        {
            this.FileType = t;
            this.Count = c;
            this.Size = s;
        }
        public string FileType;
        public int Count;
        public long Size;
    }
}
